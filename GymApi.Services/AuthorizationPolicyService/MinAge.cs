using Microsoft.AspNetCore.Authorization;

namespace GymApi.UseCases.AuthorizationPolicyService;

public class MinAge : IAuthorizationRequirement
{
    public int Age {
        get;
        set;
    } 
    public MinAge(int age)
    {
        Age = age;
    }
    
}