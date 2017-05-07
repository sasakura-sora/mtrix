namespace Matrix.Model.Events.Content
{
    public class RoomCreate
    {
        //need to seralize as m.federate
        public bool m_federate { get; set; }

        //user_id of the creator
        public string creator { get; set; }
    }
}
