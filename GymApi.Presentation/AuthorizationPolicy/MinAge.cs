using Microsoft.AspNetCore.Authorization;

namespace GymUserApi.AuthirizationPolicy;

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