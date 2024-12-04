using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
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
            _internalRepo = new Dictionary<string, IMember>();
        }
        #endregion

        #region Properties

        #endregion

        #region Methods
        public void AddMember(string name, string phone, string email)
        {
            if (_internalRepo.ContainsKey(name)) throw new KeyTakenException();
            _internalRepo[name] = new Member(name, phone, email);
        }

        public void AddMember(IMember member)
        {
            if (_internalRepo.ContainsKey(member.Name)) throw new KeyTakenException();
            _internalRepo[member.Name] = member;
        }

        #region Search and filters

            #region Individual
            public IMember GetMemberByName(string name)
            {
                if (_internalRepo.ContainsKey(name)) return _internalRepo[name];
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
            public IMember GetMemberByMail(string email)
            {
                foreach (IMember member in _internalRepo.Values)
                {
                    if (member.Email == email) return member;
                }
                throw new KeyNotFoundException();
            }
            #endregion

            #region Lists


            #endregion

        #endregion

        public void EditMember(string oldName,string newName, string phone, string email)
        {
            if(oldName == newName)
            {
                _internalRepo[oldName].Phone = phone;
                _internalRepo[oldName].Email = email;
            } else if (_internalRepo.ContainsKey(newName))
            {
                throw new KeyTakenException();
            } else
            {
                IMember tempRef = _internalRepo[oldName];
                _internalRepo.Remove(oldName);
                tempRef.Name = newName;
                tempRef.Phone = phone;
                tempRef.Email = email;
                _internalRepo[newName] = tempRef;
            }



        }


        public void RemoveMember(string name)
        {
            _internalRepo.Remove(name);
        }
        #endregion
    }
}
