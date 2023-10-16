using HarmonyLib;
using ResoniteModLoader;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using FrooxEngine;
using System.CodeDom;
using System.Reflection.Emit;

namespace RemoveComponentAttacherRestriction
{
    public class RemoveComponentAttacherRestriction : ResoniteMod
    {
        public override string Name => "RemoveComponentAttacherRestriction";
        public override string Author => "art0007i";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/art0007i/RemoveComponentAttacherRestriction/";
        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("me.art0007i.RemoveComponentAttacherRestriction");
            harmony.PatchAll();

        }
        [HarmonyPatch(typeof(SceneInspector), "OnAttachComponentPressed")]
        class RemoveComponentAttacherRestrictionPatch
        {
            public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> codes)
            {
                foreach (var code in codes)
                {
                    if(code.opcode== OpCodes.Brfalse)
                    {
                        code.opcode = OpCodes.Pop;
                    }
                    yield return code;
                }
            }
        }
    }
}