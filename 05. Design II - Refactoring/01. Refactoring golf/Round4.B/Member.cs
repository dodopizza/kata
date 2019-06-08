namespace Round4.B
{
    public class Member
    {
        private readonly string _donorMembershipId;

        public Member(string donorMembershipId)
        {
            _donorMembershipId = donorMembershipId;
        }

        public string DonorMembershipId
        {
            get { return _donorMembershipId; }
        }
    }
}