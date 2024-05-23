using BussinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDao
    {
        private static MemberDao instance = null;
        private static readonly object instanceLock = new();
        private MemberDao() { }
        public static MemberDao Instance
        {
            get
            {
                lock (instanceLock)
                {
                    instance ??= new MemberDao();
                    return instance;
                }
            }
        }

        public IEnumerable<Member> GetList()
        {
            List<Member> members;
            try
            {
                var db = new FStoreContext();
                members = db.Members.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return members;
        }

        public Member GetByEmail(string email)
        {
            Member member;
            try
            {
                var db = new FStoreContext();
                member = db.Members.FirstOrDefault(m => m.Email == email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return member;
        }

        public Member VerifyMember(Member member)
        {
            Member mb;
            List<Member> members;

            try
            {
                var db = new FStoreContext();
                members = db.Members.ToList();

                mb = db.Members.FirstOrDefault(m => m.Email == member.Email && m.Password == member.Password);

                if (mb != null)
                {
                    Console.WriteLine($"Found member: {mb.MemberId}");
                }
                else
                {
                    Console.WriteLine("No member found with provided email and password.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return mb;
        }




    }
}
