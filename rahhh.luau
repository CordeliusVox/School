local RarityManager = {}

-- Rarity definitions
RarityManager.Rarities = {
	{
		name = "Common",
		color = Color3.fromRGB(170, 170, 170),
		value = 10,
		probability = 0.60 -- 60%
	},
	{
		name = "Uncommon",
		color = Color3.fromRGB(0, 255, 0),
		value = 20,
		probability = 0.30 -- 30%
	},
	{
		name = "Rare",
		color = Color3.fromRGB(0, 0, 255),
		value = 50,
		probability = 0.05 -- 5%
	},
	{
		name = "Legendary",
		color = Color3.fromRGB(255, 215, 0),
		value = 100,
		probability = 0.05 -- 5%
	}
}

-- Debug tracking
local spawnCounts = {Common = 0, Uncommon = 0, Rare = 0, Legendary = 0}

-- Select a random rarity
function RarityManager:GetRandomRarity(): {name: string, color: Color3, value: number, probability: number}
	local rand = math.random()
	local cumulative = 0
	for _, rarity in ipairs(self.Rarities) do
		cumulative += rarity.probability
		if rand <= cumulative then
			spawnCounts[rarity.name] = spawnCounts[rarity.name] + 1
			if spawnCounts[rarity.name] % 10 == 0 then -- Log every 10 spawns
				print(string.format("Spawned %s (%d total, %.2f%%)", rarity.name, spawnCounts[rarity.name], (spawnCounts[rarity.name] / sumCounts()) * 100))
			end
			return rarity
		end
	end
	return self.Rarities[1] -- Fallback
end

-- Helper to sum spawn counts
local function sumCounts(): number
	local total = 0
	for _, count in pairs(spawnCounts) do
		total += count
	end
	return total
end

-- Reset counts (for testing)
function RarityManager:ResetCounts()
	for key in pairs(spawnCounts) do
		spawnCounts[key] = 0
	end
end

return RarityManager