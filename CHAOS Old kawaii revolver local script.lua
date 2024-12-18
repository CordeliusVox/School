Name = LocalScript
Class = LocalScript
Path = ReplicatedStorage.Equipment.Kawaii Revolver.LocalScript

JUMPIF			0		repeat
GETIMPORT		0			var0 = wait -- [REDUNDANT]
CALL			2			var0 = var0()
GETIMPORT		3			var2 = game -- [REDUNDANT]
GETTABLEKS		5			var1 = var2["Players"] -- [REDUNDANT]
GETTABLEKS		7			var0 = var1["LocalPlayer"] -- [REDUNDANT]
GETTABLEKS		8		until var0
GETIMPORT		1		var2 = game -- [REDUNDANT]
GETTABLEKS		3		var1 = var2["Players"] -- [REDUNDANT]
JUMPIF			5		repeat
GETTABLEKS		0			var0 = var1["LocalPlayer"]
GETIMPORT		2			var1 = wait -- [REDUNDANT]
CALL			4			var1 = var1()
GETTABLEKS		5			var1 = var0["Character"] -- [REDUNDANT]
GETTABLEKS		6		until var1
GETTABLEKS		6		var1 = var0["Character"]
LOADK			8		var4 = "Humanoid" -- [REDUNDANT]
NAMECALL		9		var2 = var1:WaitForChild(var4)
NAMECALL		11		var3 = var0:GetMouse()
GETIMPORT		13		var5 = script -- [REDUNDANT]
GETTABLEKS		15		var4 = var5["Parent"] -- [REDUNDANT]
LOADK			17		var6 = "Barrel" -- [REDUNDANT]
NAMECALL		18		var4 = var4:WaitForChild(var6)
LOADK			20		var7 = "Attachment" -- [REDUNDANT]
NAMECALL		21		var5 = var4:WaitForChild(var7)
GETIMPORT		23		var7 = game -- [REDUNDANT]
GETTABLEKS		25		var6 = var7["Workspace"] -- [REDUNDANT]
LOADK			27		var8 = "Target Filter"
NAMECALL		28		var6 = var6:WaitForChild(var8)
SETTABLEKS		30		var3["TargetFilter"] = var6
LOADK			32		var8 = "Animator" -- [REDUNDANT]
NAMECALL		33		var6 = var2:WaitForChild(var8)
GETIMPORT		35		var10 = script -- [REDUNDANT]
GETTABLEKS		37		var9 = var10["Parent"] -- [REDUNDANT]
LOADK			39		var11 = "Idle" -- [REDUNDANT]
NAMECALL		40		var9 = var9:WaitForChild(var11)
NAMECALL		42		var7 = var6:LoadAnimation(var9)
GETIMPORT		44		var11 = script
GETTABLEKS		46		var10 = var11["Parent"] -- [REDUNDANT]
LOADK			48		var12 = "Fire"
NAMECALL		49		var10 = var10:WaitForChild(var12)
NAMECALL		51		var8 = var6:LoadAnimation(var10)
GETIMPORT		53		var9 = game -- [REDUNDANT]
LOADK			55		var11 = "ReplicatedStorage" -- [REDUNDANT]
NAMECALL		56		var9 = var9:GetService(var11)
LOADK			58		var12 = "Revolver Bullet" -- [REDUNDANT]
NAMECALL		59		var10 = var9:WaitForChild(var12)
GETIMPORT		61		var11 = game -- [REDUNDANT]
LOADK			63		var13 = "TweenService" -- [REDUNDANT]
NAMECALL		64		var11 = var11:GetService(var13)
GETIMPORT		66		var12 = game -- [REDUNDANT]
LOADK			68		var14 = "RunService" -- [REDUNDANT]
NAMECALL		69		var12 = var12:GetService(var14)
GETIMPORT		71		var14 = script -- [REDUNDANT]
GETTABLEKS		73		var13 = var14["Parent"] -- [REDUNDANT]
LOADK			75		var15 = "ReplicateRemote" -- [REDUNDANT]
NAMECALL		76		var13 = var13:WaitForChild(var15)
GETIMPORT		78		var15 = script -- [REDUNDANT]
GETTABLEKS		80		var14 = var15["Parent"] -- [REDUNDANT]
LOADK			82		var16 = "DamageRemote"
NAMECALL		83		var14 = var14:WaitForChild(var16)
LOADK			85		var17 = "Ragdolled" -- [REDUNDANT]
NAMECALL		86		var15 = var1:WaitForChild(var17)
LOADB			88		var16 = true
DUPCLOSURE		89		upvalue[1_var1] = var1
DUPCLOSURE		90		upvalue[2_var10] = var10
DUPCLOSURE		91		upvalue[3_var11] = var11
DUPCLOSURE		92		upvalue[4_var14] = var14
DUPCLOSURE		93		local Fire = function(arg0, arg1) -- line: 27
LOADK			0			var4 = "Sound" -- [REDUNDANT]
NAMECALL		1			var2 = arg0:FindFirstChild(var4)
JUMPIFNOT		3			if var2 then
GETTABLEKS		0				var2 = arg0["Sound"] -- [REDUNDANT]
NAMECALL		2				var2 = var2:Clone()
LOADK			4				var3 = "Uncopy" -- [REDUNDANT]
SETTABLEKS		5				var2["Name"] = var3
SETTABLEKS		7				var2["Parent"] = arg0
NAMECALL		9				var3 = var2:Play()
GETIMPORT		11				var4 = game -- [REDUNDANT]
GETTABLEKS		13				var3 = var4["Debris"] -- [REDUNDANT]
MOVE			15				var5 = var2 -- [REDUNDANT]
LOADN			16				var6 = 1 -- [REDUNDANT]
NAMECALL		17				var3 = var3:AddItem(var5, var6)
NAMECALL		18			end
NEWTABLE		4			var2 = {}
GETUPVAL		6			var5 = upvalue[upvalue[1_var1]] -- [REDUNDANT]
MOVE			8			var4 = var2 -- [REDUNDANT]
GETIMPORT		9			var3 = table["insert"] -- [REDUNDANT]
CALL			11			var3 = var3(var4, var5)
GETIMPORT		12			var7 = game -- [REDUNDANT]
GETTABLEKS		14			var6 = var7["Workspace"] -- [REDUNDANT]
GETTABLEKS		16			var5 = var6["Target Filter"] -- [REDUNDANT]
MOVE			19			var4 = var2 -- [REDUNDANT]
GETIMPORT		20			var3 = table["insert"] -- [REDUNDANT]
CALL			22			var3 = var3(var4, var5)
GETIMPORT		23			var3 = pairs -- [REDUNDANT]
GETIMPORT		25			var5 = game -- [REDUNDANT]
GETTABLEKS		27			var4 = var5["Workspace"] -- [REDUNDANT]
NAMECALL		29			var4 = var4:GetDescendants()
CALL			31			var3, var4, var5 = var3(var4)
FORGPREP_NEXT	32			for var6, var7 in var3, var4, var5 do
GETTABLEKS		0				var8 = var7["ClassName"] -- [REDUNDANT]
JUMPXEQKS		2				if var8 == "Accessory" then
MOVE			1					var9 = var2 -- [REDUNDANT]
MOVE			2					var10 = var7 -- [REDUNDANT]
GETIMPORT		3					var8 = table["insert"] -- [REDUNDANT]
CALL			5					var8 = var8(var9, var10)
CALL			5				end
JUMPXEQKS		3			end
GETIMPORT		34			var3 = Ray["new"] -- [REDUNDANT]
GETTABLEKS		36			var4 = arg0["WorldPosition"] -- [REDUNDANT]
GETTABLEKS		38			var8 = arg0["WorldPosition"] -- [REDUNDANT]
SUB				40			var7 = arg1 - var8 -- [REDUNDANT]
GETTABLEKS		41			var6 = var7["Unit"] -- [REDUNDANT]
MULK			43			var5 = var6 * 100 -- [REDUNDANT]
CALL			44			var3 = var3(var4, var5) -- [REDUNDANT]
GETIMPORT		45			var5 = game -- [REDUNDANT]
GETTABLEKS		47			var4 = var5["Workspace"] -- [REDUNDANT]
MOVE			49			var6 = var3 -- [REDUNDANT]
MOVE			50			var7 = var2 -- [REDUNDANT]
NAMECALL		51			var4, var5, var6 = var4:FindPartOnRayWithIgnoreList(var6, var7)
GETUPVAL		53			var7 = upvalue[upvalue[2_var10]] -- [REDUNDANT]
NAMECALL		54			var7 = var7:Clone()
GETIMPORT		56			var9 = game -- [REDUNDANT]
GETTABLEKS		58			var8 = var9["Debris"] -- [REDUNDANT]
MOVE			60			var10 = var7 -- [REDUNDANT]
LOADN			61			var11 = 1
NAMECALL		62			var8 = var8:AddItem(var10, var11)
GETIMPORT		64			var10 = game -- [REDUNDANT]
GETTABLEKS		66			var9 = var10["Workspace"] -- [REDUNDANT]
GETTABLEKS		68			var8 = var9["Target Filter"] -- [REDUNDANT]
SETTABLEKS		70			var7["Parent"] = var8
GETTABLEKS		72			var10 = arg0["WorldPosition"]
SUB				74			var9 = var10 - var4 -- [REDUNDANT]
GETTABLEKS		75			var8 = var9["Magnitude"]
LOADK			77			var10 = 0.2 -- [REDUNDANT]
LOADK			78			var11 = 0.2 -- [REDUNDANT]
MOVE			80			var12 = var8 -- [REDUNDANT]
GETIMPORT		81			var9 = Vector3["new"] -- [REDUNDANT]
CALL			83			var9 = var9(var10, var11, var12) -- [REDUNDANT]
SETTABLEKS		84			var7["Size"] = var9
GETIMPORT		86			var10 = CFrame["new"] -- [REDUNDANT]
GETTABLEKS		88			var11 = arg0["WorldPosition"] -- [REDUNDANT]
MOVE			90			var12 = arg1
CALL			91			var10 = var10(var11, var12)
GETIMPORT		92			var11 = CFrame["new"] -- [REDUNDANT]
LOADN			94			var12 = 0 -- [REDUNDANT]
LOADN			95			var13 = 0
MINUS			96			var15 = -var8 -- [REDUNDANT]
DIVK			97			var14 = var15 / 2 -- [REDUNDANT]
CALL			98			var11 = var11(var12, var13, var14) -- [REDUNDANT]
MUL				99			var9 = var10 * var11 -- [REDUNDANT]
SETTABLEKS		100			var7["CFrame"] = var9
GETIMPORT		102			var9 = TweenInfo["new"] -- [REDUNDANT]
LOADK			104			var10 = 0.3 -- [REDUNDANT]
GETIMPORT		105			var11 = Enum["EasingStyle"]["Linear"] -- [REDUNDANT]
GETIMPORT		107			var12 = Enum["EasingDirection"]["Out"]
CALL			109			var9 = var9(var10, var11, var12) -- [REDUNDANT]
DUPTABLE		110			var10 = {
								["Transparency"] = 1;
							} -- [REDUNDANT]
LOADK			111			var12 = 0.05 -- [REDUNDANT]
LOADK			112			var13 = 0.05 -- [REDUNDANT]
MOVE			114			var14 = var8 -- [REDUNDANT]
GETIMPORT		115			var11 = Vector3["new"] -- [REDUNDANT]
CALL			117			var11 = var11(var12, var13, var14) -- [REDUNDANT]
SETTABLEKS		118			var10["Size"] = var11
GETUPVAL		122			var11 = upvalue[upvalue[3_var11]] -- [REDUNDANT]
MOVE			123			var13 = var7
MOVE			124			var14 = var9 -- [REDUNDANT]
MOVE			125			var15 = var10 -- [REDUNDANT]
NAMECALL		126			var11 = var11:Create(var13, var14, var15)
NAMECALL		128			var12 = var11:Play()
JUMPIFNOT		130			if var4 then
GETIMPORT		0				var12 = Instance["new"] -- [REDUNDANT]
LOADK			2				var13 = "Part" -- [REDUNDANT]
CALL			3				var12 = var12(var13)
GETIMPORT		4				var14 = game -- [REDUNDANT]
GETTABLEKS		6				var13 = var14["Debris"] -- [REDUNDANT]
MOVE			8				var15 = var12 -- [REDUNDANT]
LOADN			9				var16 = 2 -- [REDUNDANT]
NAMECALL		10				var13 = var13:AddItem(var15, var16)
LOADK			12				var13 = "Exploding Neon Part"
SETTABLEKS		13				var12["Name"] = var13
LOADB			15				var13 = true
SETTABLEKS		16				var12["Anchored"] = var13
LOADB			18				var13 = false
SETTABLEKS		19				var12["CanCollide"] = var13
LOADK			21				var13 = "Ball" -- [REDUNDANT]
SETTABLEKS		22				var12["Shape"] = var13
GETIMPORT		24				var13 = Enum["Material"]["Neon"] -- [REDUNDANT]
SETTABLEKS		26				var12["Material"] = var13
GETTABLEKS		28				var13 = var7["BrickColor"]
SETTABLEKS		30				var12["BrickColor"] = var13
LOADK			32				var13 = Vector3.new(0.10000000149011612, 0.10000000149011612, 0.10000000149011612, 0) -- [REDUNDANT]
SETTABLEKS		33				var12["Size"] = var13
GETIMPORT		35				var15 = game -- [REDUNDANT]
GETTABLEKS		37				var14 = var15["Workspace"]
GETTABLEKS		39				var13 = var14["Target Filter"] -- [REDUNDANT]
SETTABLEKS		41				var12["Parent"] = var13
SETTABLEKS		43				var12["Position"] = var5
GETIMPORT		45				var13 = TweenInfo["new"] -- [REDUNDANT]
LOADK			47				var14 = 0.2 -- [REDUNDANT]
GETIMPORT		48				var15 = Enum["EasingStyle"]["Linear"]
GETIMPORT		50				var16 = Enum["EasingDirection"]["Out"] -- [REDUNDANT]
CALL			52				var13 = var13(var14, var15, var16) -- [REDUNDANT]
DUPTABLE		53				var14 = {
									["Size"] = Vector3.new(2, 2, 2, 0);
									["Transparency"] = 1;
								} -- [REDUNDANT]
GETUPVAL		58				var15 = upvalue[upvalue[3_var11]] -- [REDUNDANT]
MOVE			59				var17 = var12 -- [REDUNDANT]
MOVE			60				var18 = var13
MOVE			61				var19 = var14 -- [REDUNDANT]
NAMECALL		62				var15 = var15:Create(var17, var18, var19)
NAMECALL		64				var16 = var15:Play()
GETTABLEKS		66				var16 = var4["Parent"] -- [REDUNDANT]
LOADK			68				var18 = "Humanoid" -- [REDUNDANT]
NAMECALL		69				var16 = var16:FindFirstChild(var18)
JUMPIFNOT		71				if var16 then
GETUPVAL		0					var16 = upvalue[upvalue[4_var14]] -- [REDUNDANT]
GETTABLEKS		1					var19 = var4["Parent"] -- [REDUNDANT]
GETTABLEKS		3					var18 = var19["Humanoid"] -- [REDUNDANT]
NAMECALL		5					var16 = var16:FireServer(var18)
NAMECALL		6				end
NAMECALL		6			end
RETURN			131			return 
RETURN			131		end
GETIMPORT		94		var20 = script -- [REDUNDANT]
GETTABLEKS		96		var19 = var20["Parent"] -- [REDUNDANT]
GETTABLEKS		98		var18 = var19["Activated"] -- [REDUNDANT]
NEWCLOSURE		100		upvalue[1_var2] = var2
NEWCLOSURE		101		upvalue[2_var15] = var15
NEWCLOSURE		102		upvalue[3_var16] = var16
NEWCLOSURE		103		upvalue[4_var8] = var8
NEWCLOSURE		104		upvalue[5_Fire] = Fire
NEWCLOSURE		105		upvalue[6_var5] = var5
NEWCLOSURE		106		upvalue[7_var3] = var3
NEWCLOSURE		107		upvalue[8_var13] = var13
NEWCLOSURE		108		var20 = function() -- line: 77
GETUPVAL		0			var1 = upvalue[upvalue[1_var2]]
GETTABLEKS		1			var0 = var1["Health"]
LOADN			3			var1 = 0 -- [REDUNDANT]
JUMPIFNOTLT		4			if var1 < var0 then
GETUPVAL		0				var1 = upvalue[upvalue[2_var15]] -- [REDUNDANT]
GETTABLEKS		1				var0 = var1["Value"] -- [REDUNDANT]
JUMPXEQKB		3				if var0 == false then
GETUPVAL		0					var0 = upvalue[upvalue[3_var16]]
JUMPXEQKB		1					if var0 == true then
LOADB			0						var0 = false -- [REDUNDANT]
SETUPVAL		1						upvalue[upvalue[3_var16]] = var0
GETUPVAL		2						var0 = upvalue[upvalue[4_var8]] -- [REDUNDANT]
NAMECALL		3						var0 = var0:Play()
GETUPVAL		5						var0 = upvalue[upvalue[4_var8]] -- [REDUNDANT]
LOADK			6						var2 = 0.8 -- [REDUNDANT]
NAMECALL		7						var0 = var0:AdjustSpeed(var2)
DUPCLOSURE		9						upvalue[1_upvalue[5_Fire]] = upvalue[5_Fire]
DUPCLOSURE		10						upvalue[2_upvalue[6_var5]] = upvalue[6_var5]
DUPCLOSURE		11						upvalue[3_upvalue[7_var3]] = upvalue[7_var3]
DUPCLOSURE		12						local FireBullet = function() -- line: 84
GETUPVAL		0							var0 = upvalue[upvalue[1_upvalue[5_Fire]]] -- [REDUNDANT]
GETUPVAL		1							var1 = upvalue[upvalue[2_upvalue[6_var5]]] -- [REDUNDANT]
GETUPVAL		2							var4 = upvalue[upvalue[3_upvalue[7_var3]]] -- [REDUNDANT]
GETTABLEKS		3							var3 = var4["Hit"] -- [REDUNDANT]
GETTABLEKS		5							var2 = var3["p"] -- [REDUNDANT]
CALL			7							var0 = var0(var1, var2)
RETURN			8							return 
RETURN			8						end
GETIMPORT		13						var1 = spawn -- [REDUNDANT]
MOVE			15						var2 = FireBullet
CALL			16						var1 = var1(var2)
GETUPVAL		17						var1 = upvalue[upvalue[8_var13]] -- [REDUNDANT]
GETUPVAL		18						var5 = upvalue[upvalue[7_var3]] -- [REDUNDANT]
GETTABLEKS		19						var4 = var5["Hit"] -- [REDUNDANT]
GETTABLEKS		21						var3 = var4["p"] -- [REDUNDANT]
NAMECALL		23						var1 = var1:FireServer(var3)
GETIMPORT		25						var1 = wait -- [REDUNDANT]
LOADN			27						var2 = 1 -- [REDUNDANT]
CALL			28						var1 = var1(var2) -- [REDUNDANT]
LOADB			29						var1 = true -- [REDUNDANT]
SETUPVAL		30						upvalue[upvalue[3_var16]] = var1
SETUPVAL		30					end
JUMPXEQKB		2				end
JUMPXEQKB		4			end
RETURN			6			return 
RETURN			6		end
NAMECALL		109		var18 = var18:Connect(var20)
GETIMPORT		111		var20 = script -- [REDUNDANT]
GETTABLEKS		113		var19 = var20["Parent"] -- [REDUNDANT]
GETTABLEKS		115		var18 = var19["Equipped"] -- [REDUNDANT]
DUPCLOSURE		117		upvalue[1_var7] = var7
DUPCLOSURE		118		var20 = function() -- line: 96
GETUPVAL		0			var0 = upvalue[upvalue[1_var7]] -- [REDUNDANT]
NAMECALL		1			var0 = var0:Play()
RETURN			3			return 
RETURN			3		end
NAMECALL		119		var18 = var18:Connect(var20)
GETIMPORT		121		var20 = script -- [REDUNDANT]
GETTABLEKS		123		var19 = var20["Parent"] -- [REDUNDANT]
GETTABLEKS		125		var18 = var19["Unequipped"] -- [REDUNDANT]
DUPCLOSURE		127		upvalue[1_var7] = var7
DUPCLOSURE		128		var20 = function() -- line: 99
GETUPVAL		0			var0 = upvalue[upvalue[1_var7]] -- [REDUNDANT]
NAMECALL		1			var0 = var0:Stop()
RETURN			3			return 
RETURN			3		end
NAMECALL		129		var18 = var18:Connect(var20)
RETURN			131		return 
