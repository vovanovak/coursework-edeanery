namespace EDeanery.PL.Models
{
    public class DormitoryRoomSelectModel : DormitoryRoomGetModel
    {
        public bool Checked { get; set; }

        public DormitoryRoomSelectModel(
            bool @checked, 
            DormitoryRoomGetModel dormitoryRoomGetModel) : base(dormitoryRoomGetModel)
        {
            Checked = @checked;
        }
    }
}