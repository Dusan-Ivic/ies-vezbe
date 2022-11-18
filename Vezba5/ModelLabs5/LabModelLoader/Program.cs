using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTN;

namespace LabModelLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseVoltage> baseVoltages = new List<BaseVoltage>();
            List<PowerTransformer> powerTransformers = new List<PowerTransformer>();
            List<TransformerWinding> transformerWindings = new List<TransformerWinding>();
            List<WindingTest> windingTests = new List<WindingTest>();

            // INSTANCIRANJE OBJEKATA

            BaseVoltage bv1 = new BaseVoltage()
            {
                NominalVoltage = 20,
                MRID = "MRID_BV1",
                Description = "Description_BV1"
            };

            BaseVoltage bv2 = new BaseVoltage()
            {
                NominalVoltage = 40,
                MRID = "MRID_BV2",
                Description = "Description_BV2"
            };

            baseVoltages.Add(bv1);
            baseVoltages.Add(bv2);

            for (int i = 0; i < 20; i++)
            {
                PowerTransformer pt = new PowerTransformer()
                {
                    MRID = $"MRID_PT{i + 1}",
                    Description = $"Description_PT{i + 1}"
                };

                powerTransformers.Add(pt);

                TransformerWinding tw1 = new TransformerWinding()
                {
                    MRID = "MRID_TW1",
                    Description = "Description_TW1",
                    PowerTransformer = pt,
                    BaseVoltage = bv1
                };

                TransformerWinding tw2 = new TransformerWinding()
                {
                    MRID = "MRID_TW2",
                    Description = "Description_TW2",
                    PowerTransformer = pt,
                    BaseVoltage = bv2
                };

                transformerWindings.Add(tw1);
                transformerWindings.Add(tw2);

                WindingTest wt1 = new WindingTest()
                {
                    MRID = "MRID_WT1",
                    Description = "Description_WT1",
                    From_TransformerWinding = tw1
                };

                WindingTest wt2 = new WindingTest()
                {
                    MRID = "MRID_WT2",
                    Description = "Description_WT2",
                    From_TransformerWinding = tw2
                };

                windingTests.Add(wt1);
                windingTests.Add(wt2);
            }

            // GENERISANJE IZLAZA

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < baseVoltages.Count; i++)
            {
                sb.AppendLine($"BV{i+1} - {baseVoltages[i].NominalVoltage} ({baseVoltages[i].MRID}, {baseVoltages[i].Description})");
            }

            for (int i = 0; i < powerTransformers.Count; i++)
            {
                sb.AppendLine();

                sb.AppendLine($"PT{i + 1} ({powerTransformers[i].MRID}, {powerTransformers[i].Description})");

                List<TransformerWinding> windings = transformerWindings.FindAll(tw => tw.PowerTransformer == powerTransformers[i]);
                for (int j = 0; j < windings.Count; j++)
                {
                    sb.AppendLine($"\tTW{j + 1} ({windings[j].MRID}, {windings[j].Description})");

                    List<WindingTest> tests = windingTests.FindAll(wt => wt.From_TransformerWinding == windings[j]);
                    for (int k = 0; k < tests.Count; k++)
                    {
                        sb.AppendLine($"\t\tWT{k + 1} ({tests[k].MRID}, {tests[k].Description})");
                    }
                }
            }

            // UPIS U FAJL
            Console.WriteLine(sb.ToString());
            File.WriteAllText("output.txt", sb.ToString());

            Console.ReadLine();
        }
    }
}
