// GENERATED AUTOMATICALLY FROM 'Assets/InputSettings.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSettings : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSettings()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSettings"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""8eba91a0-f96b-4834-94e6-8a937a5f751b"",
            ""actions"": [
                {
                    ""name"": ""RotationLR"",
                    ""type"": ""Value"",
                    ""id"": ""1c557ab8-c7a5-43d7-b74b-82d43d19e727"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotationUD"",
                    ""type"": ""Value"",
                    ""id"": ""8a1513ea-5a82-4090-a189-0bcfe0272fcb"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StrafeLR"",
                    ""type"": ""Value"",
                    ""id"": ""36f95baf-cf07-4a57-ade7-a4cdd9d37c5c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StopEngine"",
                    ""type"": ""Button"",
                    ""id"": ""d31793d3-5c2e-488e-a94e-7c1154752d9d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""8ed0fec8-36e6-4288-8a6a-1d4891dd4fc5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""a4e84564-c0cc-4ec2-bee5-bf44df85563c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""1865241a-d61e-4d3c-a5cd-50257f8c4357"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Horizontal wasd"",
                    ""id"": ""c4dc8661-fb3e-41b4-8915-ec980696edf3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationLR"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1d7b78f2-2120-41c6-ae42-61df33d453c8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a4dbe74b-542a-466c-8951-9cd129e6a22c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Horizontal Arrows"",
                    ""id"": ""7966a2c1-0c31-42cf-9bd0-ab6afd3e0e80"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationLR"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""84196ccc-cf7f-4d48-9a61-a889c424132b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0ecf1e9d-f16c-4b31-9473-b3c20e8f35ba"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""71571f77-6f80-40e0-955a-ee6e772ead1a"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RotationLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cd2453b-9170-43c4-8b31-7d0358081efc"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RotationUD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e6d77ca-7f4d-4c34-9e07-5d98381b5e63"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""StrafeLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Horizontal Strafe QE"",
                    ""id"": ""77bd8dec-6b46-45dc-8287-6d44ffd7961e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StrafeLR"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2d90ed8f-01de-403b-8d75-51e1104438be"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StrafeLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5e623b7d-9e1a-4616-b9fe-e4cd1e921953"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StrafeLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Horizontal Strafe autour fleche"",
                    ""id"": ""03264558-2771-409a-ae1c-b7592af7a081"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StrafeLR"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""520fd526-cd99-4ee1-81be-0a87c494e0a7"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StrafeLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""53019459-9ef7-4011-8990-019531843de9"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StrafeLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""16d089ba-71b0-43b5-8041-535df0ff6dd5"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""StopEngine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""942025a1-bdd7-4357-8480-e80d622f641c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""StopEngine"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Vertical Arrows"",
                    ""id"": ""dd9bbaf1-5c7a-426b-b07e-6d2c0d1509b0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationUD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5ba4eff4-c7b6-48ad-85bf-063856f5baf8"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationUD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ee474f05-178f-4977-a027-2f6bb8978e28"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationUD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Vertical wasd"",
                    ""id"": ""a12f162b-bcaa-46ae-8fc9-8abbd1091f1c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationUD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b197833e-8382-4976-948c-bb27c2bfd7dd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationUD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6c28823c-4713-405a-822f-5d88050f64fa"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationUD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9b668b51-207c-4b3c-b35e-f42a923a31c4"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RotationUD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae62831b-980f-4338-9970-34e3ac539864"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2884d68b-7cac-4064-aa77-8497007563f5"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49af2db4-a2e3-4a20-ae7f-1f4b66773256"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c9d23e7-4cf5-4bc2-b1a7-eb86342e6faf"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d19872d-5342-4887-a8aa-790705c3502b"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1994297-2c99-479f-a7ee-26cae66bac2f"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pawn"",
            ""id"": ""9de2a352-9937-439e-a0f1-a7c94daa2dd7"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""37607a79-10bd-4472-b799-5d5beb5b198d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""f43206b7-58b3-4ea2-adcc-60295b68c0cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Horizontal Arrows"",
                    ""id"": ""dbbf11b1-e1a9-46b2-8f6b-4d333d5b60b3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""933986e9-d951-4972-90ff-c8372531d629"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""389c38d5-313f-499f-abfe-83a9ee7a72ec"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""714c3bb0-1a1a-46a8-a3ef-4b0a8001631c"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8297905-7fb5-4801-90fc-87dcb6f7ded0"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dba442a8-8cad-4c7b-85f8-cb5363b601ab"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Level"",
            ""id"": ""b286175a-8760-4150-86a7-4d5cd55f4953"",
            ""actions"": [
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""06568e4c-9a95-4b5c-94d6-eaf453fd64cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotationUD"",
                    ""type"": ""Value"",
                    ""id"": ""9afe83d5-700a-4006-a0be-3d507aad9f57"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotationLR"",
                    ""type"": ""Value"",
                    ""id"": ""b7bf5ec5-fdcd-4eb4-85a8-9831f1a93a46"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Translation"",
                    ""type"": ""Button"",
                    ""id"": ""ae33555c-1b28-4c20-a64b-e986435da15a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""QE"",
                    ""id"": ""e0a5b858-2617-4d1a-8f10-66f5fd258f22"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Translation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e395078f-1a14-46fc-adba-6ad15ed0ee12"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Translation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6b5e755e-eba9-45f3-93ab-f7e939fa5ee3"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Translation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Triggers"",
                    ""id"": ""67272163-fc98-4e84-be6a-554707fd5476"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Translation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""cfc4b1f5-0d90-4d68-a8c6-ab6548e72818"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Translation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c206cead-d669-4a36-9bf9-e7ebf9bea17a"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Translation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""AD"",
                    ""id"": ""f2837524-b876-4481-bace-ff1f7b722677"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationLR"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""bde52438-791a-4bfb-a3ea-fecc12beeecf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fd9672a7-7f2d-4833-b09a-28c8030bc10b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cc7bef81-dc07-40aa-bd4e-f3c4efd4266f"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RotationLR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""SW"",
                    ""id"": ""ddb331c2-1336-489a-8ebc-8f8ffdbec49a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotationUD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""32ca8785-f0c1-46df-95f5-90064e4b9503"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationUD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3cfee8be-a517-4454-8c70-d370277af6cc"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotationUD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0f039dc8-b80d-4ece-a289-078ce2545d31"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RotationUD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f69c9e9-2fa9-4ec2-b7cc-5a193b877be3"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d698ead-9343-4865-9d36-4a053831fccb"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_RotationLR = m_Player.FindAction("RotationLR", throwIfNotFound: true);
        m_Player_RotationUD = m_Player.FindAction("RotationUD", throwIfNotFound: true);
        m_Player_StrafeLR = m_Player.FindAction("StrafeLR", throwIfNotFound: true);
        m_Player_StopEngine = m_Player.FindAction("StopEngine", throwIfNotFound: true);
        m_Player_Restart = m_Player.FindAction("Restart", throwIfNotFound: true);
        m_Player_Accelerate = m_Player.FindAction("Accelerate", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        // Pawn
        m_Pawn = asset.FindActionMap("Pawn", throwIfNotFound: true);
        m_Pawn_Move = m_Pawn.FindAction("Move", throwIfNotFound: true);
        m_Pawn_Restart = m_Pawn.FindAction("Restart", throwIfNotFound: true);
        // Level
        m_Level = asset.FindActionMap("Level", throwIfNotFound: true);
        m_Level_Restart = m_Level.FindAction("Restart", throwIfNotFound: true);
        m_Level_RotationUD = m_Level.FindAction("RotationUD", throwIfNotFound: true);
        m_Level_RotationLR = m_Level.FindAction("RotationLR", throwIfNotFound: true);
        m_Level_Translation = m_Level.FindAction("Translation", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_RotationLR;
    private readonly InputAction m_Player_RotationUD;
    private readonly InputAction m_Player_StrafeLR;
    private readonly InputAction m_Player_StopEngine;
    private readonly InputAction m_Player_Restart;
    private readonly InputAction m_Player_Accelerate;
    private readonly InputAction m_Player_Pause;
    public struct PlayerActions
    {
        private @InputSettings m_Wrapper;
        public PlayerActions(@InputSettings wrapper) { m_Wrapper = wrapper; }
        public InputAction @RotationLR => m_Wrapper.m_Player_RotationLR;
        public InputAction @RotationUD => m_Wrapper.m_Player_RotationUD;
        public InputAction @StrafeLR => m_Wrapper.m_Player_StrafeLR;
        public InputAction @StopEngine => m_Wrapper.m_Player_StopEngine;
        public InputAction @Restart => m_Wrapper.m_Player_Restart;
        public InputAction @Accelerate => m_Wrapper.m_Player_Accelerate;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @RotationLR.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotationLR;
                @RotationLR.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotationLR;
                @RotationLR.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotationLR;
                @RotationUD.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotationUD;
                @RotationUD.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotationUD;
                @RotationUD.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotationUD;
                @StrafeLR.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrafeLR;
                @StrafeLR.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrafeLR;
                @StrafeLR.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrafeLR;
                @StopEngine.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStopEngine;
                @StopEngine.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStopEngine;
                @StopEngine.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStopEngine;
                @Restart.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestart;
                @Accelerate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAccelerate;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RotationLR.started += instance.OnRotationLR;
                @RotationLR.performed += instance.OnRotationLR;
                @RotationLR.canceled += instance.OnRotationLR;
                @RotationUD.started += instance.OnRotationUD;
                @RotationUD.performed += instance.OnRotationUD;
                @RotationUD.canceled += instance.OnRotationUD;
                @StrafeLR.started += instance.OnStrafeLR;
                @StrafeLR.performed += instance.OnStrafeLR;
                @StrafeLR.canceled += instance.OnStrafeLR;
                @StopEngine.started += instance.OnStopEngine;
                @StopEngine.performed += instance.OnStopEngine;
                @StopEngine.canceled += instance.OnStopEngine;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Pawn
    private readonly InputActionMap m_Pawn;
    private IPawnActions m_PawnActionsCallbackInterface;
    private readonly InputAction m_Pawn_Move;
    private readonly InputAction m_Pawn_Restart;
    public struct PawnActions
    {
        private @InputSettings m_Wrapper;
        public PawnActions(@InputSettings wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Pawn_Move;
        public InputAction @Restart => m_Wrapper.m_Pawn_Restart;
        public InputActionMap Get() { return m_Wrapper.m_Pawn; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PawnActions set) { return set.Get(); }
        public void SetCallbacks(IPawnActions instance)
        {
            if (m_Wrapper.m_PawnActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PawnActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PawnActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PawnActionsCallbackInterface.OnMove;
                @Restart.started -= m_Wrapper.m_PawnActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_PawnActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_PawnActionsCallbackInterface.OnRestart;
            }
            m_Wrapper.m_PawnActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
            }
        }
    }
    public PawnActions @Pawn => new PawnActions(this);

    // Level
    private readonly InputActionMap m_Level;
    private ILevelActions m_LevelActionsCallbackInterface;
    private readonly InputAction m_Level_Restart;
    private readonly InputAction m_Level_RotationUD;
    private readonly InputAction m_Level_RotationLR;
    private readonly InputAction m_Level_Translation;
    public struct LevelActions
    {
        private @InputSettings m_Wrapper;
        public LevelActions(@InputSettings wrapper) { m_Wrapper = wrapper; }
        public InputAction @Restart => m_Wrapper.m_Level_Restart;
        public InputAction @RotationUD => m_Wrapper.m_Level_RotationUD;
        public InputAction @RotationLR => m_Wrapper.m_Level_RotationLR;
        public InputAction @Translation => m_Wrapper.m_Level_Translation;
        public InputActionMap Get() { return m_Wrapper.m_Level; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LevelActions set) { return set.Get(); }
        public void SetCallbacks(ILevelActions instance)
        {
            if (m_Wrapper.m_LevelActionsCallbackInterface != null)
            {
                @Restart.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnRestart;
                @RotationUD.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnRotationUD;
                @RotationUD.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnRotationUD;
                @RotationUD.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnRotationUD;
                @RotationLR.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnRotationLR;
                @RotationLR.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnRotationLR;
                @RotationLR.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnRotationLR;
                @Translation.started -= m_Wrapper.m_LevelActionsCallbackInterface.OnTranslation;
                @Translation.performed -= m_Wrapper.m_LevelActionsCallbackInterface.OnTranslation;
                @Translation.canceled -= m_Wrapper.m_LevelActionsCallbackInterface.OnTranslation;
            }
            m_Wrapper.m_LevelActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @RotationUD.started += instance.OnRotationUD;
                @RotationUD.performed += instance.OnRotationUD;
                @RotationUD.canceled += instance.OnRotationUD;
                @RotationLR.started += instance.OnRotationLR;
                @RotationLR.performed += instance.OnRotationLR;
                @RotationLR.canceled += instance.OnRotationLR;
                @Translation.started += instance.OnTranslation;
                @Translation.performed += instance.OnTranslation;
                @Translation.canceled += instance.OnTranslation;
            }
        }
    }
    public LevelActions @Level => new LevelActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnRotationLR(InputAction.CallbackContext context);
        void OnRotationUD(InputAction.CallbackContext context);
        void OnStrafeLR(InputAction.CallbackContext context);
        void OnStopEngine(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnAccelerate(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IPawnActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
    }
    public interface ILevelActions
    {
        void OnRestart(InputAction.CallbackContext context);
        void OnRotationUD(InputAction.CallbackContext context);
        void OnRotationLR(InputAction.CallbackContext context);
        void OnTranslation(InputAction.CallbackContext context);
    }
}
