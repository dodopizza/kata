namespace Round4.B
{
    public class Title
    {
        private readonly string _titleName;
        private readonly Member _donor;
        private int _copyCount;

        public Title(string titleName, Member donor)
        {
            _titleName = titleName;
            _donor = donor;
            _copyCount = 1;
        }

        public string TitleName
        {
            get { return _titleName; }
        }

        public int CopyCount
        {
            get { return _copyCount; }
        }

        public object DonorId
        {
            get { return _donor.DonorMembershipId; }
        }
    }
}