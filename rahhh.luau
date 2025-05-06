local RarityManager = {}

RarityManager.Rarities = {
	{
		Name = "Common",
		Color = Color3.fromRGB(14, 255, 102),
		Value = 10,
		Probabillity = 0.6 -- 60%
	},
	{
		Name = "Uncommon",
		Color = Color3.fromRGB(255, 0, 0),
		Value = 20,
		Probabillity = 0.3 -- 30%
	},
	{
		Name = "Rare",
		Color = Color3.fromRGB(30, 0, 255),
		Value = 50,
		Probabillity = 0.25 -- 25%
	},
	{
		Name = "Epic",
		Color = Color3.fromRGB(255, 255, 255),
		Value = 100,
		Probabillity = 1 -- 10%
	},
	{
		Name = "Legendary",
		Color = Color3.fromRGB(0, 0, 0),
		Value = 500,
		Probabillity = 0.01 -- 1%
	},
}

local SpawnCounts = {Common = 0, Uncommon = 0, Rare = 0, Epic = 0, Legendary = 0} -- Debug

local function SumCounts(): (number)
	local Total = 0
	for _, count in pairs(SpawnCounts) do
		Total += count
	end
	return Total
end

function RarityManager:GetRandomRarity(): ({Name: string, Color: Color3, Value: number, Probability: number})
	local Rnd = math.random()
	local Cumulative = 0
	
	for _, Rarity in ipairs(self.Rarities) do
		Cumulative = Cumulative + Rarity.Probabillity
		if Rnd <= Cumulative then
			SpawnCounts[Rarity.Name] = SpawnCounts[Rarity.Name] + 1
			if SpawnCounts[Rarity.Name] % 10 == 0 then
				print(string.format("Spawned %s (%d total, %.2f%%)", Rarity.Name, SpawnCounts[Rarity.Name], (SpawnCounts[Rarity.Name] / SumCounts()) * 100))
			end
			
			return Rarity
		end
	end
	
	return self.Rarities[1]
end

function RarityManager:ResetCounts()
	for Key in pairs(SpawnCounts) do
		SpawnCounts[Key] = 0
	end
end


return RarityManager
