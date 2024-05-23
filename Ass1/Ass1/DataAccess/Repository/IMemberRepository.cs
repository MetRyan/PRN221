using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable <Member> getList();
        Member GetMemberbyEmail(String email);
        Member verifyMember(Member member);


    }
}
