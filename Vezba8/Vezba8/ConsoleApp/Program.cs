using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FTN.Common;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Base Voltage 1

            ResourceDescription baseVoltage1 = new ResourceDescription()
            {
                Id = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.BASEVOLTAGE, -1)
            };
            
            baseVoltage1.AddProperty(new Property(ModelCode.IDOBJ_MRID, "BV1"));
            baseVoltage1.AddProperty(new Property(ModelCode.IDOBJ_NAME, "baseVoltage1_name"));
            baseVoltage1.AddProperty(new Property(ModelCode.IDOBJ_DESCRIPTION, "baseVoltage1_description"));
            baseVoltage1.AddProperty(new Property(ModelCode.BASEVOLTAGE_NOMINALVOLTAGE, (float)110));

            // Base Voltage 2

            ResourceDescription baseVoltage2 = new ResourceDescription()
            {
                Id = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.BASEVOLTAGE, -2)
            };

            baseVoltage2.AddProperty(new Property(ModelCode.IDOBJ_MRID, "BV2"));
            baseVoltage2.AddProperty(new Property(ModelCode.IDOBJ_NAME, "baseVoltage2_name"));
            baseVoltage2.AddProperty(new Property(ModelCode.IDOBJ_DESCRIPTION, "baseVoltage2_description"));
            baseVoltage2.AddProperty(new Property(ModelCode.BASEVOLTAGE_NOMINALVOLTAGE, (float)20));

            // Location

            ResourceDescription location = new ResourceDescription()
            {
                Id = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.LOCATION, -1)
            };
            location.AddProperty(new Property(ModelCode.IDOBJ_MRID, "LOC"));
            location.AddProperty(new Property(ModelCode.IDOBJ_NAME, "location_name"));
            location.AddProperty(new Property(ModelCode.IDOBJ_DESCRIPTION, "location_description"));
            location.AddProperty(new Property(ModelCode.LOCATION_CATEGORY, "location_category"));
            location.AddProperty(new Property(ModelCode.LOCATION_CORPORATECODE, "location_corporate_code"));

            // Power Transformer

            ResourceDescription powerTransformer = new ResourceDescription()
            {
                Id = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.POWERTR, -1)
            };

            powerTransformer.AddProperty(new Property(ModelCode.IDOBJ_MRID, "PW"));
            powerTransformer.AddProperty(new Property(ModelCode.IDOBJ_NAME, "powerTransformer_name"));
            powerTransformer.AddProperty(new Property(ModelCode.IDOBJ_DESCRIPTION, "powerTransformer_description"));
            powerTransformer.AddProperty(new Property(ModelCode.PSR_LOCATION, location.Id));
            powerTransformer.AddProperty(new Property(ModelCode.PSR_CUSTOMTYPE, "powerTransformer_custom_type"));
            powerTransformer.AddProperty(new Property(ModelCode.EQUIPMENT_ISPRIVATE, false));
            powerTransformer.AddProperty(new Property(ModelCode.EQUIPMENT_ISUNDERGROUND, true));
            powerTransformer.AddProperty(new Property(ModelCode.POWERTR_FUNC, (short)TransformerFunction.Generator));
            powerTransformer.AddProperty(new Property(ModelCode.POWERTR_AUTO, true));

            // Transformer Winding 1
            ResourceDescription transformerWinding1 = new ResourceDescription()
            {
                Id = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.POWERTRWINDING, -1)
            };

            transformerWinding1.AddProperty(new Property(ModelCode.IDOBJ_MRID, "TW1"));
            transformerWinding1.AddProperty(new Property(ModelCode.IDOBJ_NAME, "transformerWinding1_name"));
            transformerWinding1.AddProperty(new Property(ModelCode.IDOBJ_DESCRIPTION, "transformerWinding1_description"));
            transformerWinding1.AddProperty(new Property(ModelCode.PSR_CUSTOMTYPE, "transformerWinding1_custom_type"));
            transformerWinding1.AddProperty(new Property(ModelCode.EQUIPMENT_ISPRIVATE, false));
            transformerWinding1.AddProperty(new Property(ModelCode.EQUIPMENT_ISUNDERGROUND, true));
            transformerWinding1.AddProperty(new Property(ModelCode.CONDEQ_BASVOLTAGE, baseVoltage1.Id));
            transformerWinding1.AddProperty(new Property(ModelCode.CONDEQ_PHASES, (short)PhaseCode.ABCN));
            transformerWinding1.AddProperty(new Property(ModelCode.CONDEQ_RATEDVOLTAGE, (float)1));
            transformerWinding1.AddProperty(new Property(ModelCode.POWERTRWINDING_POWERTRW, powerTransformer.Id));
            transformerWinding1.AddProperty(new Property(ModelCode.POWERTRWINDING_CONNTYPE, (short)WindingConnection.OD));
            transformerWinding1.AddProperty(new Property(ModelCode.POWERTRWINDING_GROUNDED, true));
            transformerWinding1.AddProperty(new Property(ModelCode.POWERTRWINDING_RATEDS, (float)0));
            transformerWinding1.AddProperty(new Property(ModelCode.POWERTRWINDING_RATEDU, (float)1));
            transformerWinding1.AddProperty(new Property(ModelCode.POWERTRWINDING_PHASETOGRNDVOLTAGE, (float)0));
            transformerWinding1.AddProperty(new Property(ModelCode.POWERTRWINDING_PHASETOPHASEVOLTAGE, (float)1));
            transformerWinding1.AddProperty(new Property(ModelCode.POWERTRWINDING_WINDTYPE, (short)WindingType.Primary));

            // Transformer Winding 2

            ResourceDescription transformerWinding2 = new ResourceDescription()
            {
                Id = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.POWERTRWINDING, -2)
            };

            transformerWinding2.AddProperty(new Property(ModelCode.IDOBJ_MRID, "TW2"));
            transformerWinding2.AddProperty(new Property(ModelCode.IDOBJ_NAME, "transformerWinding2_name"));
            transformerWinding2.AddProperty(new Property(ModelCode.IDOBJ_DESCRIPTION, "transformerWinding2_description"));
            transformerWinding2.AddProperty(new Property(ModelCode.PSR_CUSTOMTYPE, "transformerWinding2_custom_type"));
            transformerWinding2.AddProperty(new Property(ModelCode.EQUIPMENT_ISPRIVATE, false));
            transformerWinding2.AddProperty(new Property(ModelCode.EQUIPMENT_ISUNDERGROUND, true));
            transformerWinding2.AddProperty(new Property(ModelCode.CONDEQ_BASVOLTAGE, baseVoltage2.Id));
            transformerWinding2.AddProperty(new Property(ModelCode.CONDEQ_PHASES, (short)PhaseCode.ABCN));
            transformerWinding2.AddProperty(new Property(ModelCode.CONDEQ_RATEDVOLTAGE, (float)1));
            transformerWinding2.AddProperty(new Property(ModelCode.POWERTRWINDING_POWERTRW, powerTransformer.Id));
            transformerWinding2.AddProperty(new Property(ModelCode.POWERTRWINDING_CONNTYPE, (short)WindingConnection.OD));
            transformerWinding2.AddProperty(new Property(ModelCode.POWERTRWINDING_GROUNDED, true));
            transformerWinding2.AddProperty(new Property(ModelCode.POWERTRWINDING_RATEDS, (float)0));
            transformerWinding2.AddProperty(new Property(ModelCode.POWERTRWINDING_RATEDU, (float)1));
            transformerWinding2.AddProperty(new Property(ModelCode.POWERTRWINDING_PHASETOGRNDVOLTAGE, (float)0));
            transformerWinding2.AddProperty(new Property(ModelCode.POWERTRWINDING_PHASETOPHASEVOLTAGE, (float)1));
            transformerWinding2.AddProperty(new Property(ModelCode.POWERTRWINDING_WINDTYPE, (short)WindingType.Primary));

            // Insert operacije i čuvanje u XML fajl

            Delta delta = new Delta();

            delta.AddDeltaOperation(DeltaOpType.Insert, baseVoltage1, true);
            delta.AddDeltaOperation(DeltaOpType.Insert, baseVoltage2, true);
            delta.AddDeltaOperation(DeltaOpType.Insert, location, true);
            delta.AddDeltaOperation(DeltaOpType.Insert, powerTransformer, true);
            delta.AddDeltaOperation(DeltaOpType.Insert, transformerWinding1, true);
            delta.AddDeltaOperation(DeltaOpType.Insert, transformerWinding2, true);

            string xmlFilename = "output.xml";

            using (XmlTextWriter writer = new XmlTextWriter(xmlFilename, null))
            {
                delta.ExportToXml(writer);
                Console.WriteLine($"Sačuvano u ConsoleApp/bin/Debug/{xmlFilename}");
            }
        }
    }
}
