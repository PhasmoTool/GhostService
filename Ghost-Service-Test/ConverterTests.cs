using NUnit.Framework;
using GhostService_API.Converters;
using GhostService_API.Models;
using GhostService_API.Models.RequestModels;
using GhostService_API.Models.ResponseModels;
using System.Collections.Generic;
using System.Linq;

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

            EvidenceRequestModel evidenceReqModel2 = new EvidenceRequestModel()
            {
                EvidenceType = EvidenceType.secondary,
                Name = "early hunter"
            };

            Evidence evidenceDbModel = EvidenceModelConverter.ConvertRequestModelToDatabaseModel(evidenceReqModel);
            Evidence evidenceDbModel2 = EvidenceModelConverter.ConvertRequestModelToDatabaseModel(evidenceReqModel2);

            Assert.AreEqual(evidenceReqModel.Name, evidenceDbModel.Name);
            Assert.AreEqual(evidenceReqModel.EvidenceType, evidenceDbModel.EvidenceType);

            Assert.AreEqual(evidenceReqModel2.Name, evidenceDbModel2.Name);
            Assert.AreEqual(evidenceReqModel2.EvidenceType, evidenceDbModel2.EvidenceType);
        }

        [Test]
        public void EvidenceDataToResponseConverterTest()
        {
            Evidence evidenceDataModel = new Evidence()
            {
                Id = 1,
                EvidenceType = EvidenceType.primary,
                Name = "freezing"
            };

            Evidence evidenceDataModel2 = new Evidence()
            {
                Id = 2,
                EvidenceType = EvidenceType.secondary,
                Name = "early hunter"
            };

            EvidenceResponse response1 = EvidenceModelConverter.ConvertDatabaseModelToResponseModel(evidenceDataModel);
            EvidenceResponse response2 = EvidenceModelConverter.ConvertDatabaseModelToResponseModel(evidenceDataModel2);

            Assert.AreEqual(evidenceDataModel.Id, response1.Id);
            Assert.AreEqual(evidenceDataModel.Name, response1.Name);
            Assert.AreEqual(evidenceDataModel.EvidenceType, response1.EvidenceType);

            Assert.AreEqual(evidenceDataModel2.Id, response2.Id);
            Assert.AreEqual(evidenceDataModel2.Name, response2.Name);
            Assert.AreEqual(evidenceDataModel2.EvidenceType, response2.EvidenceType);
        }

        [Test]
        public void GhostRequestToDataConverterTest()
        {
            GhostRequestModel ghostRequest1 = new GhostRequestModel()
            {
                Name = "Banshee",
                EvidenceIds = new List<long> { 1, 2, 3}
            };

            GhostRequestModel ghostRequest2 = new GhostRequestModel()
            {
                Name = "Mimic",
                EvidenceIds = new List<long> { 1, 2, 3, 4}
            };

            Ghost ghostData1 = GhostModelConverter.ConvertRequestModelToDatabaseModel(ghostRequest1);
            Ghost ghostData2 = GhostModelConverter.ConvertRequestModelToDatabaseModel(ghostRequest2);

            Assert.AreEqual(ghostRequest1.Name, ghostData1.Name);
            foreach(var ghostId in ghostRequest1.EvidenceIds)
            {
                Assert.IsTrue(ghostData1.Evidence.Any(x => x.EvidenceId == ghostId));
            }

            Assert.AreEqual(ghostRequest2.Name, ghostData2.Name);
            foreach (var ghostId in ghostRequest2.EvidenceIds)
            {
                Assert.IsTrue(ghostData2.Evidence.Any(x => x.EvidenceId == ghostId));
            }
        }

        [Test]
        public void GhostDataToResponseConverterTest()
        {
            Ghost ghostData1 = new Ghost()
            {
                Id = 1,
                Name = "Banshee",
                Evidence = new List<GhostEvidence>()
                {
                    new GhostEvidence()
                    {
                        EvidenceId = 1,
                        GhostId = 1,
                        Ghost = null,
                        Evidence = new Evidence()
                        {
                            Name = "freezing",
                            Id = 1,
                            EvidenceType = EvidenceType.primary
                        }
                    }
                }
            };

            Ghost ghostData2 = new Ghost()
            {
                Id = 2,
                Name = "Mimic",
                Evidence = new List<GhostEvidence>()
                {
                    new GhostEvidence()
                    {
                        EvidenceId = 2,
                        GhostId = 2,
                        Ghost = null,
                        Evidence = new Evidence()
                        {
                            Name = "spirit box",
                            Id = 2,
                            EvidenceType = EvidenceType.primary
                        }
                    }
                }
            };

            GhostResponse response1 = GhostModelConverter.ConvertDatabaseModelToResponseModel(ghostData1);
            GhostResponse response2 = GhostModelConverter.ConvertDatabaseModelToResponseModel(ghostData2);

            Assert.AreEqual(ghostData1.Name, response1.Name);
            Assert.AreEqual(ghostData1.Id, response1.Id);

            foreach(var evidence in response1.Evidences)
            {
                Assert.IsTrue(ghostData1.Evidence.Any(x => x.Evidence.EvidenceType == evidence.EvidenceType));
                Assert.IsTrue(ghostData1.Evidence.Any(x => x.Evidence.Id == evidence.Id));
                Assert.IsTrue(ghostData1.Evidence.Any(x => x.Evidence.Name == evidence.Name));
            }

            Assert.AreEqual(ghostData2.Name, response2.Name);
            Assert.AreEqual(ghostData2.Id, response2.Id);

            foreach (var evidence in response2.Evidences)
            {
                Assert.IsTrue(ghostData2.Evidence.Any(x => x.Evidence.EvidenceType == evidence.EvidenceType));
                Assert.IsTrue(ghostData2.Evidence.Any(x => x.Evidence.Id == evidence.Id));
                Assert.IsTrue(ghostData2.Evidence.Any(x => x.Evidence.Name == evidence.Name));
            }
        }
    }
}