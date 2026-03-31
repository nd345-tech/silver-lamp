using Terraria.ModLoader;

namespace TutorialMod.Content.WorldGeneration
{
    public class InProgressBackgroundStyle : ModSurfaceBackgroundStyle
    {
        // Use this to keep far Backgrounds like the mountains.
        public override void ModifyFarFades(float[] fades, float transitionSpeed)
        {
            for (int i = 0; i < fades.Length; i++)
            {
                if (i == Slot)
                {
                    fades[i] += transitionSpeed;
                    if (fades[i] > 1f)
                    {
                        fades[i] = 1f;
                    }
                }
                else
                {
                    fades[i] -= transitionSpeed;
                    if (fades[i] < 0f)
                    {
                        fades[i] = 0f;
                    }
                }
            }
        }

        public override int ChooseFarTexture()
        {
            return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/InProgressSurfaceFar");
        }

        private static int SurfaceFrameCounter;
        private static int SurfaceFrame;
        public override int ChooseMiddleTexture()
        {
            
            switch (SurfaceFrame)
            {
                case 0:
                    return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/InProgressSurfaceMid0");
                default:
                    return -1;
            }
        }

        public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
        {
            return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/InProgressSurfaceClose");
        }
    }
}
