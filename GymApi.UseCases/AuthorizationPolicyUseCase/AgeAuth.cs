using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace GymApi.UseCases.AuthorizationPolicyUseCase;

public class AgeAuth : AuthorizationHandler<MinAge>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinAge requirement)
    {
        var dateBirthClaim = context
            .User.FindFirst(claim =>
                claim.Type == ClaimTypes.DateOfBirth);

        if (dateBirthClaim is null) return Task.CompletedTask;
        
        var dateBirth = Convert.ToDateTime(dateBirthClaim.Value);

        var ageUser = DateTime.Today.Year - dateBirth.Year;

        if (dateBirth > DateTime.Today.AddYears(-ageUser)) --ageUser;

        if (ageUser >= requirement.Age) 
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}