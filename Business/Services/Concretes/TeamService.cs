using Business.Services.Abstrcats;
using Core.Models;
using Core.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concretes
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
       

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

       

        public void AddTeam(Team team)
        {
            if (team == null) throw new NullReferenceException("Null ola bilmez");
            string path = "C:\\Users\\Administrator\\Desktop\\Web_Task-master\\BB207_Mamba\\wwwroot\\Upload\\Team\\" + team.PhotoFile.FileName;
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                team.PhotoFile.CopyTo(file);
            }
            team.ImgUrl = team.PhotoFile.FileName;
            _teamRepository.Add(team);
            _teamRepository.Commit();
        }

        public List<Team> GetAllTeams(Func<Team, bool>? func = null)
        {
            return _teamRepository.GetAll(func);
        }

        public Team GetTeam(Func<Team, bool>? func = null)
        {
            return _teamRepository.Get(func);
        }

        public void RemoveTeam(int id)
        {
            Team existTeam=_teamRepository.Get(x=>x.Id==id);
            if (existTeam == null) throw new NullReferenceException("Null ola bilmez");

            string path = "C:\\Users\\Administrator\\Desktop\\Web_Task-master\\BB207_Mamba\\wwwroot\\Upload\\Team\\" + existTeam.ImgUrl;
            FileInfo fileInfo = new FileInfo(path);
            fileInfo.Delete();
            _teamRepository.Delete(existTeam);
            _teamRepository.Commit();
        }

        public void UpdateTeam(int id, Team team)
        {
            Team oldTeam = _teamRepository.Get(x => x.Id == id);
            if (oldTeam == null) throw new NullReferenceException("Null ola bilmez");

            if (team.PhotoFile != null)
            {
                string path = "C:\\Users\\Administrator\\Desktop\\Web_Task-master\\BB207_Mamba\\wwwroot\\Upload\\Team\\" + team.PhotoFile.FileName;
                using (FileStream file = new FileStream(path, FileMode.Create))
                {
                    team.PhotoFile.CopyTo(file);
                }
                string path2 = "C:\\Users\\Administrator\\Desktop\\Web_Task-master\\BB207_Mamba\\wwwroot\\Upload\\Team\\" + oldTeam.ImgUrl;
                FileInfo fileInfo = new FileInfo(path2);
                fileInfo.Delete();
                oldTeam.ImgUrl=team.PhotoFile.FileName;
            }

            oldTeam.Name= team.Name;
            oldTeam.Title= team.Title;
            _teamRepository.Commit();
        }
    }
}
