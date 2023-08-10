using FinalCase.Base;
using FinalCase.Schema;

namespace FinalCase.Operation.Token;

public interface ITokenService
{
    ApiResponse<TokenResponse> Login(TokenRequest request);
}
