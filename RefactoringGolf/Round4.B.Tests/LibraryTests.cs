using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyModel;
using Xunit;

namespace Round4.B
{
    public class LibraryTests
    {
        [Fact]
        public void DonatedTitlesAreAddedToLibraryWithOneDefaultCopy()
        {
            Library library = new Library();
            String titleName = "Jaws 3D";
            String donorId = "Jason123";
            Member member = new Member(donorId);
            Title title = new Title(titleName, member);
            library.Donate(title);
            Title donatedTitle = library.GetTitles()[titleName];
            Assert.Equal(titleName, title.TitleName);
            Assert.Equal(donorId, title.DonorId);
            Assert.Equal(1, title.CopyCount);
            Assert.Equal(1, library.GetTitlesDonatedByMember(donorId).Count);
        }
    }
}
