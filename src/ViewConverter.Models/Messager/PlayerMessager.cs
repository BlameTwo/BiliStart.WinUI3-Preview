using Network.Models.Enum;
using ViewConverter.Models;

namespace ViewConverter.Models.Messager;

public enum CommonOpenEnum
{
    Open,
    Close
}

public record PlayerCommonData(RepliesItem DataSource, CommonOpenEnum OpenEnum, CommentType type);

public record PlayerGoBackMain(bool flage);
