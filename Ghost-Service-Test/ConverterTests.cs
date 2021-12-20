using NUnit.Framework;
using GhostService_API.Converters;
using GhostService_API.Models;
using GhostService_API.Models.RequestModels;
using GhostService_API.Models.ResponseModels;

namespace Ghost_Service_Test
{
    public class ConverterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EvidenceRequestToDataConverterTest()
        {
            EvidenceRequestModel evidenceReqModel = new EvidenceRequestModel()
            {
                EvidenceType = EvidenceType.primary,
                Name = "freezing"
            };

            Evidence evidenceDbModel = EvidenceModelConverter.ConvertRequestModelToDatabaseModel(evidenceReqModel);

            Assert.AreEqual(evidenceReqModel.Name, evidenceDbModel.Name);
            Assert.AreEqual(evidenceReqModel.EvidenceType, evidenceDbModel.EvidenceType);
        }
    }
}