local socket = require("socket.core")

local connection
local host = "127.0.0.1"
local port = 39876
local connected = false
local stopped = false
local version = "1.3"

local active_text = "Test"
local text_timer = 18
local retry_timer = 0

function read_bytes(address, number)
  bytes = {}

  for i = 0, number - 1 do
    table.insert(bytes, mainmemory.read_u8(address + i))
  end

  return bytes
end

function write_byte(address, value)
  mainmemory.write_u8(address, value)
end

function on_message(s)
  local parts = {}

  for part in string.gmatch(s, "([^,]+)") do
    parts[#parts + 1] = part
  end

  if parts[1] == "read" then
    local address = tonumber(parts[2])
    local number = tonumber(parts[3])
    --console.log("Reading " .. number .. " bytes at " .. address)

    connection:send('[' .. table.concat(read_bytes(address, number), ",") .. "]\n")
    --console.log("Sent")

  elseif parts[1] == "raddr" then
    local bytes = {}

    for k, v in pairs(parts) do
      if k > 2 then
        bytes[k - 1] = read_bytes(v, 1);
      end
    end

    connection:send('[' .. table.concat(bytes), "," .. "]\n")

  elseif parts[1] == "write" then
    local address = tonumber(parts[2])
    console.log("Writing to " .. address)

    for k, v in pairs(parts) do
      if k > 2 then
        write_byte(address + k - 3, tonumber(v))
      end
    end

    connection:send("[0]\n")

  elseif parts[1] == "text" then
    active_text = parts[2]
    text_timer = 300
  end
end

function main()
  if stopped then
    return nil
  end

  if not connected then
    -- Do not attempt if we haven't reset our retry timer.
    if retry_timer > 0 then
      retry_timer = retry_timer - 1
      return
    end

    console.log("OoT:R Bridge v" .. version)
    console.log("Connecting to MultiClient at " .. host .. ":" .. port)

    connection, err = socket:tcp()
    if err ~= nil then
      console.log("Error: ", err)
      return
    end

    local return_code, error_message = connection:connect(host, port)
    if return_code == nil then
      console.log("Error while connecting: ", error_message)
      --stopped = true
      connected = false
      console.log("Will retry to connect in 5 seconds...")
      retry_timer = 300
      return
    end

    connection:settimeout(0)
    connected = true
    console.log("Connected to MultiClient")
    return
  end

  local s, status = connection:receive("*l")
  if s then
    on_message(s)
  end

  if status == "closed" then
    console.log("Connection to MultiClient was closed.")
    console.log("Will retry to connect in 5 seconds...")
    retry_timer = 300

    text_timer = 300
    active_text = "Lost connection to MultiClient."

    connection:close()
    connected = false
    return
  end
end

function draw_gui()
  -- Messages
  gui.drawString(0, 237, active_text, null, null, null, null, null, "top")

  -- Connected Message
  local conn_text, conn_color
  if connected then
    conn_text = "Ready"
    conn_color = "lime"
  else
    conn_text = "Disconnected"
    conn_color = "red"
  end

  gui.drawString(320, 237, conn_text, conn_color, null, null, null, "right", "top")

  if text_timer > 0 then
    text_timer = text_timer - 1
  end

  if text_timer == 0 then
    active_text = ""
  end
end

gui.DrawNew("emu", true)
while true do
  main()

  draw_gui()

  emu.frameadvance()
end
