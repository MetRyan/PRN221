using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public IEnumerable<Member> getList() => MemberDao.Instance.GetList();

        public Member GetMemberbyEmail(String email) => MemberDao.Instance.GetByEmail(email);

        public Member verifyMember(Member member) => MemberDao.Instance.VerifyMember(member);
    }
}
