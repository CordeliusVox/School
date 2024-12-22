Name = Sprinting
Class = LocalScript
Path = StarterGui.Sprinting.Sprinting

JUMPIF			0		repeat
GETIMPORT		0			var0 = wait 
CALL			2			var0 = var0()
GETIMPORT		3			var2 = game 
GETTABLEKS		5			var1 = var2["Players"] 
GETTABLEKS		7			var0 = var1["LocalPlayer"] 
GETTABLEKS		8		until var0
GETIMPORT		1		var2 = game 
GETTABLEKS		3		var1 = var2["Players"] 
JUMPIF			5		repeat
GETTABLEKS		0			var0 = var1["LocalPlayer"]
GETIMPORT		2			var1 = wait 
CALL			4			var1 = var1()
GETTABLEKS		5			var1 = var0["Character"]
GETTABLEKS		6		until var1
GETTABLEKS		6		var1 = var0["Character"]
LOADK			8		var4 = "HumanoidRootPart" 
NAMECALL		9		var2 = var1:WaitForChild(var4)
LOADK			11		var5 = "Humanoid" 
NAMECALL		12		var3 = var1:WaitForChild(var5)
LOADK			14		var6 = "Animator" 
NAMECALL		15		var4 = var3:WaitForChild(var6)
GETIMPORT		17		var7 = script 
LOADK			19		var9 = "Animation"
NAMECALL		20		var7 = var7:WaitForChild(var9)
NAMECALL		22		var5 = var4:LoadAnimation(var7)
GETIMPORT		24		var8 = script 
LOADK			26		var10 = "Animation2"
NAMECALL		27		var8 = var8:WaitForChild(var10)
NAMECALL		29		var6 = var4:LoadAnimation(var8)
LOADK			31		var9 = "Sitting" 
NAMECALL		32		var7 = var1:WaitForChild(var9)
GETIMPORT		34		var8 = game 
LOADK			36		var10 = "UserInputService" 
NAMECALL		37		var8 = var8:GetService(var10)
GETIMPORT		39		var10 = script 
GETTABLEKS		41		var9 = var10["Parent"] 
LOADK			43		var11 = "Frame" 
NAMECALL		44		var9 = var9:WaitForChild(var11)
LOADK			46		var12 = "Frame" 
NAMECALL		47		var10 = var9:WaitForChild(var12)
GETIMPORT		49		var14 = script
GETTABLEKS		51		var13 = var14["Parent"]
GETTABLEKS		53		var12 = var13["Sprint"]
GETTABLEKS		55		var11 = var12["TextButton"]
LOADB			57		var12 = false -- Bool1
LOADB			58		var13 = false -- Bool2
LOADB			59		var14 = true -- Bool3
LOADN			60		var15 = 100
LOADK			61		var18 = "Ragdolled" 
NAMECALL		62		var16 = var1:WaitForChild(var18)
LOADN			64		var17 = 14 
SETTABLEKS		65		var3["WalkSpeed"] = var17 -- Setting default speed to var17 (14)

GETTABLEKS		67		var17 = var8["InputBegan"] -- UserInputService.InputBegan
NEWCLOSURE		69		upvalue[1_var13] = var13 -- Boolean2
NEWCLOSURE		70		upvalue[2_var3] = var3 -- Humanoid
NEWCLOSURE		71		upvalue[3_var7] = var7 -- Sitting Bool
NEWCLOSURE		72		var19 = function(arg0, arg1) -- line: 30 -- UserInputService.InputBegan:Connect(function(Input, GamePro)
JUMPIF			0			if not arg1 then -- If not GamePro then
GETTABLEKS		0				var2 = arg0["UserInputType"] -- Input.UserInputType
GETIMPORT		2				var3 = Enum["UserInputType"]["Keyboard"] -- Enum.UserInputType.Keyboard
JUMPIFNOTEQ		4				if var2 == var3 then -- If Input.UserInputType == Enum.UserInputType.Keyboard then
GETTABLEKS		0					var2 = arg0["KeyCode"] -- Input.KeyCode
GETIMPORT		2					var3 = Enum["KeyCode"]["LeftShift"] -- Enum.KeyCode.LeftShift
JUMPIFNOTEQ		4					if var2 == var3 then -- if Input.KeyCode == Enum.KeyCode.LeftShift then
LOADB			0						var2 = true 
SETUPVAL		1						upvalue[upvalue[1_var13]] = var2 -- Setting Bool2 to true
GETUPVAL		2						var2 = upvalue[upvalue[2_var3]] -- Humanoid
LOADN			3						var3 = 20
SETTABLEKS		4						var2["WalkSpeed"] = var3 -- Setting humanoid's walkspeed to 20
GETUPVAL		6						var2 = upvalue[upvalue[3_var7]] 
LOADB			7						var3 = false 
SETTABLEKS		8						var2["Value"] = var3 -- Setting the sitting bool to false
SETTABLEKS		9					end
JUMPIFNOTEQ		5				end
JUMPIFNOTEQ		5			end
RETURN			1			return 
RETURN			1		end
NAMECALL		73		var17 = var17:Connect(var19) -- UserInputService.InputBegan:Connect(function(Input, GamePro) from above!!!!!!!

GETTABLEKS		75		var17 = var8["InputEnded"] -- UserInputService.InputEnded
NEWCLOSURE		77		upvalue[1_var13] = var13 -- Boolean2
NEWCLOSURE		78		upvalue[2_var3] = var3 -- Humanoid
NEWCLOSURE		79		var19 = function(arg0, arg1) -- line: 41 -- UserInputService.InputEnded:Connect(function(Input, GamePro)
JUMPIF			0			if not arg1 then -- if not GamePro then
GETTABLEKS		0				var2 = arg0["UserInputType"] -- Input.UserInputType
GETIMPORT		2				var3 = Enum["UserInputType"]["Keyboard"] -- Enum.UserInputType.Keyboard
JUMPIFNOTEQ		4				if var2 == var3 then -- if Input.UserInputType == Enum.UserInputType.Keyboard then
GETTABLEKS		0					var2 = arg0["KeyCode"] -- Input.KeyCode
GETIMPORT		2					var3 = Enum["KeyCode"]["LeftShift"] -- Enum.KeyCode.LeftShift
JUMPIFNOTEQ		4					if var2 == var3 then -- if Input.KeyCode == Enum.KeyCode.LeftShift then
LOADB			0						var2 = false 
SETUPVAL		1						upvalue[upvalue[1_var13]] = var2 -- Setting Bool2 to false
GETUPVAL		2						var2 = upvalue[upvalue[2_var3]] -- Humanoid
LOADN			3						var3 = 14 
SETTABLEKS		4						var2["WalkSpeed"] = var3 -- Setting humanoid's walkspeed to 14
SETTABLEKS		5					end
JUMPIFNOTEQ		5				end
JUMPIFNOTEQ		5			end
RETURN			1			return 
RETURN			1		end
NAMECALL		80		var17 = var17:Connect(var19) -- UserInputService.InputEnded:Connect(function(Input, GamePro) from above!!!!!!!!!!

GETTABLEKS		82		var17 = var11["InputBegan"] -- Mobile Text button.InputBegan
NEWCLOSURE		84		upvalue[1_var13] = var13 -- Boolean2
NEWCLOSURE		85		upvalue[2_var3] = var3 -- Humanoid
NEWCLOSURE		86		var19 = function(arg0) -- line: 51 -- TextButton.InputBegan:Connect(function(Input)
LOADB			0			var1 = true 
SETUPVAL		1			upvalue[upvalue[1_var13]] = var1 -- Setting Bool2 to true
GETUPVAL		2			var1 = upvalue[upvalue[2_var3]] -- Humanoid
LOADN			3			var2 = 19 
SETTABLEKS		4			var1["WalkSpeed"] = var2 -- Setting humanoid's walkspeed to 19
RETURN			6			return 
RETURN			6		end
NAMECALL		87		var17 = var17:Connect(var19) -- TextButton.InputBegan:Connect(function(Input) from above!!!!!!!!

GETTABLEKS		89		var17 = var11["InputEnded"] -- Mobile Text button.InputEnded
NEWCLOSURE		91		upvalue[1_var13] = var13 -- Boolean2
NEWCLOSURE		92		upvalue[2_var3] = var3 -- Humanoid
NEWCLOSURE		93		var19 = function(arg0) -- line: 56 -- TextButton.InputEnded:Connect(function(Input)
LOADB			0			var1 = false 
SETUPVAL		1			upvalue[upvalue[1_var13]] = var1 -- Setting Bool2 to false
GETUPVAL		2			var1 = upvalue[upvalue[2_var3]] -- Humanoid
LOADN			3			var2 = 14 
SETTABLEKS		4			var1["WalkSpeed"] = var2 -- Setting humanoid's walkspeed to 14
RETURN			6			return 
RETURN			6		end
NAMECALL		94		var17 = var17:Connect(var19) -- TextButton.InputEnded:Connect(function(Input) from above!!!!!!!!!!!

NEWCLOSURE		96		upvalue[1_var3] = var3 -- Humanoid
NEWCLOSURE		97		upvalue[2_var13] = var13 -- Boolean2
NEWCLOSURE		98		upvalue[3_var12] = var12 -- Boolean1
NEWCLOSURE		99		upvalue[4_var5] = var5 -- Sprint Animation
NEWCLOSURE		100		local Update = function() -- line: 61 local function Update()
GETUPVAL		0			var1 = upvalue[upvalue[1_var3]] -- Humanoid
GETTABLEKS		1			var0 = var1["MoveDirection"] -- Humanoid.MoveDirection
LOADK			3			var1 = Vector3.new(0, 0, 0) 
JUMPIFEQ		4			if var0 ~= var1 then -- if Humanoid.MoveDirection ~= Vector3.new(0, 0, 0) then
GETUPVAL		0				var0 = upvalue[upvalue[2_var13]] -- Bool2
JUMPXEQKB		1				if var0 == true then -- If boolean2 is true
LOADB			0					var0 = true 
SETUPVAL		1					upvalue[upvalue[3_var12]] = var0 -- Set boolean1 to true
GETUPVAL		2					var1 = upvalue[upvalue[4_var5]] -- Sprint Animation
GETTABLEKS		3					var0 = var1["IsPlaying"] -- Sprint Animation.IsPlaying
JUMPXEQKB		5					if var0 == false then -- If Sprint Animation is NOT playing
GETUPVAL		0						var0 = upvalue[upvalue[4_var5]] -- Sprint Animtaion
NAMECALL		1						var0 = var0:Play() -- plays the Sprint Animtion
GETUPVAL		3						var0 = upvalue[upvalue[4_var5]] -- Sprint Animation
LOADK			4						var2 = 1.4 
NAMECALL		5						var0 = var0:AdjustSpeed(var2) -- Adjusting the animation speed to 1.4 | Sprint Animtion:AdjustSpeed(1.4) |
RETURN			7						return -- Returning (end)
GETUPVAL		8						var0 = upvalue[upvalue[4_var5]] -- Sprint Animation
NAMECALL		9						var0 = var0:Stop() -- Stopping the Sprint Animation
LOADB			11						var0 = false 
SETUPVAL		12						upvalue[upvalue[3_var12]] = var0 -- Setting Boolean1 to false
RETURN			13						return -- returning (end)
GETUPVAL		14						var0 = upvalue[upvalue[4_var5]] -- Sprint Animation
NAMECALL		15						var0 = var0:Stop() -- Stopping the Sprint Animation
LOADB			17						var0 = false 
SETUPVAL		18						upvalue[upvalue[3_var12]] = var0 -- Setting Boolean1 to false
SETUPVAL		18					end
JUMPXEQKB		6				end
JUMPXEQKB		2			end
RETURN			6			return 
RETURN			6		end

GETTABLEKS		101		var18 = var3["Changed"] -- Humanoid.Changed
DUPCLOSURE		103		upvalue[1_Update] = Update -- Update function
DUPCLOSURE		104		var20 = function() -- line: 79 -- Humanoid.Changed:Connect(function)
GETUPVAL		0			var0 = upvalue[upvalue[1_Update]] -- Update function
CALL			1			var0 = var0() -- Calling the update function | Update() |
RETURN			2			return 
RETURN			2		end
NAMECALL		105		var18 = var18:Connect(var20) -- Humanoid.Changed:Connect(function) from above!!!!!!!!!!!

GETTABLEKS		107		var18 = var8["InputBegan"] -- UserInputService.InputBegan
NEWCLOSURE		109		upvalue[1_var14] = var14 -- Boolean3
NEWCLOSURE		110		upvalue[2_var16] = var16 -- Ragdolled Boolean
NEWCLOSURE		111		upvalue[3_var6] = var6 -- Dash Animation
NEWCLOSURE		112		upvalue[4_var2] = var2 -- HumanoidRootPart
NEWCLOSURE		113		upvalue[5_var3] = var3 -- Humanoid
NEWCLOSURE		114		var20 = function(arg0, arg1) -- line: 83 -- UserInputService.InputBegan:Connect(function(Input, GamePro)
JUMPIF			0			if not arg1 then -- if not GamePro then
GETTABLEKS		0				var2 = arg0["UserInputType"] -- Input.UserInputType
GETIMPORT		2				var3 = Enum["UserInputType"]["Keyboard"] -- Enum.UserInputType.Keyboard
JUMPIFNOTEQ		4				if var2 == var3 then -- Input.UserInputType == Enum.UserInputType.Keyboard then
GETTABLEKS		0					var2 = arg0["KeyCode"] -- Input.KeyCode
GETIMPORT		2					var3 = Enum["KeyCode"]["E"] -- Enum.KeyCode.E
JUMPIFNOTEQ		4					if var2 == var3 then -- if Input.KeyCode == Enum.KeyCode.E then
GETUPVAL		0						var2 = upvalue[upvalue[1_var14]]  -- Boolean3
JUMPXEQKB		1						if var2 == true then -- If Boolean3 is true
GETUPVAL		0							var3 = upvalue[upvalue[2_var16]] -- Ragdolled Boolean
GETTABLEKS		1							var2 = var3["Value"] -- Ragdolled Boolean.Value
JUMPXEQKB		3							if var2 == false then -- if Ragdolled Boolean.Value == false then
LOADB			0								var2 = false 
SETUPVAL		1								upvalue[upvalue[1_var14]] = var2 -- Setting Boolean3 to false
GETUPVAL		2								var2 = upvalue[upvalue[3_var6]] -- Dash Animation
NAMECALL		3								var2 = var2:Play() -- Playing Dash Animation
GETIMPORT		5								var2 = Instance["new"] -- Creating a new BodyVelocity Instance
LOADK			7								var3 = "BodyVelocity"
GETUPVAL		8								var4 = upvalue[upvalue[4_var2]] -- HumanoidRootPart
CALL			9								var2 = var2(var3, var4) -- Instance.new("BodyVelocity", HumanoidRootPart)
LOADK			10								var3 = Vector3.new(20000, 0, 20000) 
SETTABLEKS		11								var2["MaxForce"] = var3 -- Setting the BodyVelocity MaxForce to Vector3.new(20000, 0, 20000) | Could use the one we have | 
GETUPVAL		13								var5 = upvalue[upvalue[5_var3]] -- Humanoid
GETTABLEKS		14								var4 = var5["MoveDirection"] -- Humanoid.MoveDirection | Could use the one we have |
LOADK			16								var5 = Vector3.new(90, 0, 90) 
MUL				17								var3 = var4 * var5 -- Humanoid.MoveDirection * Vector3.new(90, 0, 90) 
SETTABLEKS		18								var2["Velocity"] = var3 -- Setting BodyVelocity.Velocity to Humanoid.MoveDirection * Vector3.new(90, 0, 90) 
GETUPVAL		20								var4 = upvalue[upvalue[5_var3]] -- Humanoid
GETTABLEKS		21								var3 = var4["MoveDirection"] -- Humanoid.MoveDirection
LOADK			23								var4 = Vector3.new(0, 0, 0)
JUMPIFNOTEQ		24								if var3 == var4 then -- if Humanoid.MoveDirection == Vector3.new(0, 0, 0) then
GETUPVAL		0									var6 = upvalue[upvalue[4_var2]] -- HumanoidRootPart
GETTABLEKS		1									var5 = var6["CFrame"] -- HumanoidRootPart.CFrame
GETTABLEKS		3									var4 = var5["lookVector"] -- HumanoidRootPart.CFrame.LookVector
LOADK			5									var5 = Vector3.new(90, 0, 90) 
MUL				6									var3 = var4 * var5 -- HumanoidRootPart.CFrame.LookVector * Vector3.new(90, 0, 90) 
SETTABLEKS		7									var2["Velocity"] = var3 -- Setting BodyVelocity.Velocity to HumanoidRootPart.CFrame.LookVector * Vector3.new(90, 0, 90) 
SETTABLEKS		8								end
GETIMPORT		26								var4 = game
GETTABLEKS		28								var3 = var4["Debris"] -- Debris Service
MOVE			30								var5 = var2 -- BodyVelocity
LOADK			31								var6 = 0.2 
NAMECALL		32								var3 = var3:AddItem(var5, var6) -- DebrisService:AddItem(BodyVelocity, 0.2) -- Delets the body velocity after 0.2 seconds
GETIMPORT		34								var3 = wait 
LOADN			36								var4 = 2 
            
CALL			37								var3 = var3(var4) -- waiting 2 seconds | task.wait(2) |
LOADB			38								var3 = true 
SETUPVAL		39								upvalue[upvalue[1_var14]] = var3 -- Setting Boolean3 to true
SETUPVAL		39							end
JUMPXEQKB		4						end
JUMPXEQKB		2					end
JUMPIFNOTEQ		5				end
JUMPIFNOTEQ		5			end
RETURN			1			return 
RETURN			1		end
NAMECALL		115		var18 = var18:Connect(var20) -- UserInputService.InputBegan:Connect(function(Input, GamePro) from above!!!!!!!

LOADN			117		var18 = 99
JUMPIFNOTLT		118		if var18 < var15 then
LOADB			0			var18 = false -- [REDUNDANT]
SETTABLEKS		1			var9["Visible"] = var18
SETTABLEKS		2		else
LOADB			0			var18 = true -- [REDUNDANT]
SETTABLEKS		1			var9["Visible"] = var18
SETTABLEKS		2		end
JUMPXEQKB		120		if var12 == true then
LOADN			0			var18 = 0
JUMPIFNOTLT		1			if var18 < var15 then
GETTABLEKS		0				var18 = var3["MoveDirection"] -- [REDUNDANT]
LOADK			2				var19 = Vector3.new(0, 0, 0, 0)
JUMPIFEQ		3				if var18 ~= var19 then
SUBK			0					var15 = var15 - 1
SUBK			0				end
JUMPIFEQ		4			end
LOADN			3			var18 = 1
JUMPIFNOTLT		4			if var15 < var18 then
LOADN			0				var18 = 14 -- [REDUNDANT]
SETTABLEKS		1				var3["WalkSpeed"] = var18
NAMECALL		3				var18 = var5:Stop()
LOADB			5				var12 = false -- [REDUNDANT]
LOADB			6				var13 = false
JUMPXEQKB		7				if var12 == false then
LOADN			0					var18 = 100
JUMPIFNOTLT		1					if var15 < var18 then
ADDK			0						var15 = var15 + 1
ADDK			0					end
JUMPIFNOTLT		2				end
JUMPXEQKB		8			end
JUMPIFNOTLT		5		elseif var12 == false then
LOADN			0			var18 = 100
JUMPIFNOTLT		1			if var15 < var18 then
ADDK			0				var15 = var15 + 1
ADDK			0			end
JUMPIFNOTLT		2		end
CALL			122		var18 = var18(var19, var20) -- [REDUNDANT]
SETTABLEKS		123		var10["Size"] = var18
GETIMPORT		125		var18 = wait -- [REDUNDANT]
CALL			127		var18 = var18()
RETURN			128		return 
