using System;
using System.Collections.Generic;

namespace HighfieldRecruitment.Models
{
    public class ResponseDTO
    {
        public ResponseDTO()
        {
            Users = new List<UserEntity>();
            Ages = new List<AgePlusTwentyDTO>();
            TopColours = new List<TopColoursDTO>();
        }
        public List<UserEntity> Users { get; set; }
        public List<AgePlusTwentyDTO> Ages { get; set; }
        public List<TopColoursDTO> TopColours { get; set; }
    }
}
