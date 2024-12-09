using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Data;
using ClassLibrary.Exceptions;
using ClassLibrary.Interfaces;
using ClassLibrary.Models;

namespace ClassLibrary.Services
{
    public class MemberRepository : IMemberRepository
    {
        #region Instance fields
        private Dictionary<string, IMember> _internalRepo;
        #endregion

        #region Constructors
        public MemberRepository()
        {
            //_internalRepo = new Dictionary<string, IMember>();
            _internalRepo = MockData.GetInstance().MemberData;
        }
        #endregion

        #region Properties

        #endregion

        #region Methods
        public void AddMember(string name, string phone, string email)
        {
            if (_internalRepo.ContainsKey(email)) throw new KeyTakenException();
            _internalRepo[email] = new Member(name, phone, email);
        }

        public void AddMember(IMember member)
        {
            if (_internalRepo.ContainsKey(member.Email)) throw new KeyTakenException();
            _internalRepo[member.Email] = member;
        }

        #region Search and filters

            #region Individual
            public IMember GetMemberByEmail(string email)
            {
                if (_internalRepo.ContainsKey(email)) return _internalRepo[email];
                throw new KeyNotFoundException();
            }
            public IMember GetMemberByName(string name)
            {
                foreach (IMember member in _internalRepo.Values)
                {
                    if (member.Name == name) return member;
                }
                throw new KeyNotFoundException();
            }

            public IMember GetMemberByPhone(string phone)
            {
                foreach(IMember member in _internalRepo.Values)
                {
                    if (member.Phone == phone) return member;
                }
                throw new KeyNotFoundException();
            }
            #endregion

            #region Lists
                public List<IMember> GetAll()
                {
                    return _internalRepo.Values.ToList();
                } 

            #endregion

        #endregion

        public void EditMember(string name, string phone, string email, string newEmail)
        {
            if(email == newEmail)
            {
                _internalRepo[email].Phone = phone;
                _internalRepo[email].Email = newEmail;
            } else if (_internalRepo.ContainsKey(newEmail))
            {
                throw new KeyTakenException();
            } else
            {
                IMember tempRef = _internalRepo[email];
                _internalRepo.Remove(email);
                tempRef.Name = name;
                tempRef.Phone = phone;
                tempRef.Email = newEmail;
                _internalRepo[newEmail] = tempRef;
            }



        }


        public void RemoveMember(string email)
        {
            _internalRepo.Remove(email);
        }
        #endregion
    }
}
