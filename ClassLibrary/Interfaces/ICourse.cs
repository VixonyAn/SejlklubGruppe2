﻿using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface ICourse
    {
        string Name { get; set; }
       
        int[] AttendeeRange { get; set; }
        List<Member> Attendees { get; set; }
        Member Master { get; set; }
        string Description { get; set; }
        public void AttendCourse(Member SelectedMember);
    }
}
