using System.ComponentModel.Composition;
using Ambient;
using Ambient.Visuals;
using System.Windows.Forms;
using SharpDX;
using System;

namespace CarbonMod
{
    [Export(typeof(CarbonPlugin))]
    public class CarbonMod : CarbonPlugin
    {
        private TerrainGeneration terrainGenerator;

        #region IPlugin Members

        public void Initialize(World world)
        {
            terrainGenerator = new TerrainGeneration(world);
        }

        public string Author
        {
            get
            {
                return "Ambient Software";
            }
        }

        public void GenerateChunk(
            Int3 chunkOffset,
            Voxel.Ownership owner,
            out ushort[] blocks,
            out ushort[] crust,
            out byte[] precipitationData,
            out bool containsVolcano,
            out bool containsGeyser,
            out bool containsPotentialSpring,
            out World.LifeMode lifeMode)
        {
            terrainGenerator.GenerateChunk(chunkOffset, owner, out blocks, out crust, out precipitationData, out containsVolcano, out containsGeyser, out containsPotentialSpring, out lifeMode);
        }

        public Block GetSuitableLivingBlock(Random random,
            int weightedPrecipitation,
            float temperatureWinter,
            float temperatureSummer,
            float chaos,
            Block.LivingGenerationModes vegetationType)
        {
            return terrainGenerator.GetSuitableLivingBlock(random, weightedPrecipitation, temperatureWinter, temperatureSummer, chaos, vegetationType);
        }
        #endregion
    }
}
