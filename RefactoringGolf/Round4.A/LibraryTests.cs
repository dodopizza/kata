using System;
using Xunit;

namespace Round4.A
{
    public class LibraryTests
    {
        [Fact]
        public void DonatedTitlesAreAddedToLibraryWithOneDefaultCopy()
        {
            Library library = new Library();
            String titleName = "Jaws 3D";
            String donorId = "Jason123";
            library.Donate(titleName, donorId);
            Object[] donatedTitle = library.GetTitles()[titleName];
            Assert.Equal(titleName, (String)donatedTitle[0]);
            Assert.Equal(donorId, (String)donatedTitle[1]);
            Assert.Equal(1, (int)donatedTitle[2]);
            Assert.Equal(1, library.GetTitlesDonatedByMember(donorId).Count);
        }
    }
}
