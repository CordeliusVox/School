local Players = game:GetService("Players")
local ReplicatedStorage = game:GetService("ReplicatedStorage")
local DataStoreService = game:GetService("DataStoreService")
local StarManager = require(script.Parent.StarManager)

-- Initialize Sparks folder
if not game.Workspace:FindFirstChild("Sparks") then
	Instance.new("Folder", game.Workspace).Name = "Sparks"
end

-- RemoteEvent
local catchEvent = Instance.new("RemoteEvent")
catchEvent.Name = "CatchStar"
catchEvent.Parent = ReplicatedStorage

-- Player data
local playerStarManagers = {}
local playerInventories = {}
local inventoryStore = DataStoreService:GetDataStore("PlayerInventories")

-- Configuration
local MAX_STARS_PER_PLAYER = 10
local SPAWN_AREA_MIN = Vector3.new(-25, 5, -25)
local SPAWN_AREA_MAX = Vector3.new(25, 15, 25)
local MIN_PADDING = 5 -- Minimum distance between stars (studs)

-- Player join
Players.PlayerAdded:Connect(function(player)
	-- Initialize star manager
	local starManager = StarManager.new(player, MAX_STARS_PER_PLAYER, SPAWN_AREA_MIN, SPAWN_AREA_MAX, MIN_PADDING)
	playerStarManagers[player.UserId] = starManager
	
	-- Initialize inventory
	local success, inventory = pcall(function()
		return inventoryStore:GetAsync(tostring(player.UserId)) or {Common = 0, Uncommon = 0, Rare = 0, Legendary = 0}
	end)
	if success then
		playerInventories[player.UserId] = inventory
	else
		playerInventories[player.UserId] = {Common = 0, Uncommon = 0, Rare = 0, Legendary = 0}
	end
end)

-- Player leave
Players.PlayerRemoving:Connect(function(player)
	local starManager = playerStarManagers[player.UserId]
	if starManager then
		starManager:Destroy()
		playerStarManagers[player.UserId] = nil
	end
	local inventory = playerInventories[player.UserId]
	if inventory then
		pcall(function()
			inventoryStore:SetAsync(tostring(player.UserId), inventory)
		end)
		playerInventories[player.UserId] = nil
	end
end)

-- Handle catch
catchEvent.OnServerEvent:Connect(function(player, starName)
	local starManager = playerStarManagers[player.UserId]
	if not starManager then return end
	local star = starManager.starFolder:FindFirstChild(starName)
	if not star or star.OwnerUserId.Value ~= tostring(player.UserId) then return end
	
	local rarity = star.Name:gsub("Star", "")
	playerInventories[player.UserId][rarity] = playerInventories[player.UserId][rarity] + 1
	starManager:RemoveStar(star)
	catchEvent:FireClient(player, rarity, star.Position)
end)