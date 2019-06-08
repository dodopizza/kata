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
            var library = new Library();
            var titleName = "Jaws 3D";
            var donorId = "Jason123";
            var member = new Member(donorId);
            var title = new Title(titleName, member);

            library.Donate(title);
            
            Assert.Equal(titleName, title.TitleName);
            Assert.Equal(donorId, title.DonorId);
            Assert.Equal(1, title.CopyCount);
            Assert.Single(library.GetTitlesDonatedByMember(donorId));
        }
    }
}
