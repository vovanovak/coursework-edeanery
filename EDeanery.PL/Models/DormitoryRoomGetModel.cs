using System.Collections.Generic;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.PL.Models
{
    public class DormitoryRoomGetModel
    {
        public int DormitoryRoomId { get; set; }
        public string DormityRoomName { get; set; }
        public int MaxCountInRoom { get; set; }
        public int? DormitoryId { get; set; }
        public IReadOnlyCollection<StudentGetModel> DormitoryRoomStudents { get; set; }

        public DormitoryRoomGetModel()
        {
        }

        public DormitoryRoomGetModel(DormitoryRoomGetModel dormitoryRoomGetModel)
        {
            DormitoryRoomId = dormitoryRoomGetModel.DormitoryRoomId;
            DormityRoomName = dormitoryRoomGetModel.DormityRoomName;
            MaxCountInRoom = dormitoryRoomGetModel.MaxCountInRoom;
            DormitoryId = dormitoryRoomGetModel.DormitoryId;
            DormitoryRoomStudents = dormitoryRoomGetModel.DormitoryRoomStudents;
        }
    }
}