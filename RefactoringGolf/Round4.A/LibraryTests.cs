using System;
using Xunit;

namespace Round4.A
{
    public class LibraryTests
    {
        [Fact]
        public void DonatedTitlesAreAddedToLibraryWithOneDefaultCopy()
        {
            var library = new Library();
            var titleName = "Jaws 3D";
            var donorId = "Jason123";
            library.Donate(titleName, donorId);
            var donatedTitle = library.GetTitles()[titleName];
            Assert.Equal(titleName, (String)donatedTitle[0]);
            Assert.Equal(donorId, (String)donatedTitle[1]);
            Assert.Equal(1, (int)donatedTitle[2]);
            Assert.Single(library.GetTitlesDonatedByMember(donorId));
        }
    }
}
