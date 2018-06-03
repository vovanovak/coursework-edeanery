using System.Collections.Generic;
using EDeanery.BLL.Domain.Entities;

namespace EDeanery.PL.Models
{
    public class DormitoryRoomGetModel
    {
        public int DormitoryRoomId { get; set; }
        public string DormitoryRoomName { get; set; }
        public int MaxCountInRoom { get; set; }
        public int FreeSpacesCount { get; set; }
        public DormitoryGetModel Dormitory { get; set; }
        public IReadOnlyCollection<StudentGetModel> DormitoryRoomStudents { get; set; }

        public DormitoryRoomGetModel()
        {
        }

        public DormitoryRoomGetModel(DormitoryRoomGetModel dormitoryRoomGetModel)
        {
            DormitoryRoomId = dormitoryRoomGetModel.DormitoryRoomId;
            DormitoryRoomName = dormitoryRoomGetModel.DormitoryRoomName;
            MaxCountInRoom = dormitoryRoomGetModel.MaxCountInRoom;
            Dormitory = dormitoryRoomGetModel.Dormitory;
            DormitoryRoomStudents = dormitoryRoomGetModel.DormitoryRoomStudents;
        }
    }
}