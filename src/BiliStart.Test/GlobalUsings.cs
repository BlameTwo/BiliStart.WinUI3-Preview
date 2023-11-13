global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using BiliNetWork;
global using INetwork.IProviders;
global using App.Models.MediaPlayerArgs;
global using INetwork;
global using BiliNetWork.Providers;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using IViewConverter;
global using ViewConverter;
namespace BiliStart.Test;

/*
 �����Ե�Ԫ������Api���ݽӿ����
 
 */

public static class TestService
{
    public static void Register()
    {
        Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder().RegisterNetwork().Build();
        ((IHttpClientProvider)TestService.Host.Services.GetService(typeof(IHttpClientProvider))!).InitClient();
        //�����TokenName������Ϊ���浽���ݣ�������Ա����Ե�Ԫ�������ȵ�½���޸�����ֵ�ٲ��ԡ�
        ((ICurrent)TestService.Host.Services.GetService(typeof(ICurrent))!).TokenName = 108534711;

    }

    public static IHost Host = null;

    public static IHostBuilder RegisterNetwork(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(
            (contenxt, service) =>
            {
                //����ͷ��װ
                service.AddSingleton<IRequestMessage, RequestMessage>();
                //Http��֤��չ
                service.AddSingleton<IHttpExtensions, HttpExtensions>();
                //��¼������
                service.AddSingleton<ILoginProvider, LoginProvider>();
                //�������������
                service.AddTransient<ISearchProvider, SearchProvider>();
                //��ͨ��Ƶ������
                service.AddSingleton<IVideoProvider, VideoProvider>();
                //�˻�������
                service.AddSingleton<IAccountProvider, AccountProvider>();
                //�˻���Ϣ������
                service.AddSingleton<IMessagerProvider, MessagerProvider>();
                //��ý�������
                service.AddSingleton<IBangumiProvider, BangumiProvider>();
                //Http������
                service.AddSingleton<IHttpClientProvider, HttpClientProvider>();
                //����������
                service.AddSingleton<ITidProvider, TidProvider>();
                //��Ļ������
                service.AddSingleton<IDanmakuProvider, DanmakuProvider>();
                //Bվ�Ķ��ķ��������
                service.AddSingleton<IBiliServiceProvider, BiliServiceProvider>();
                //����ת��������
                service.AddSingleton<IAvToBvConverter, AvToBvConverter>();
                //�ظ�������
                service.AddSingleton<IReplyProvider, ReplyProvider>();
                //����Token��ȡ�ӿ�
                service.AddSingleton<IAccountTokenSet, AccountTokenSet>();
                //Token����
                service.AddSingleton<ITokenManager, TokenManager>();
                //Bվ�������л�ת��
                service.AddSingleton<IBIliDocument, BIliDocument>();
                //��BiliBili��API
                service.AddSingleton<IThirdApiProvider, ThirdApiProvider>();
                //ֱ����ؿ�����
                service.AddSingleton<ILiveProvider, LiveProvider>();
                
                service.AddSingleton<ICurrent,Current>();

                service.AddSingleton<IFileEncryptionProviderService, FileEncryptionProviderService>();

                service.AddSingleton<IVideoViewModelConverter, VideoViewModelConverter>();
                service.AddSingleton<IPlayerViewModelConverter, PlayerViewModelConverter>();
                service.AddSingleton<IBiliDataViewModelConverter, BiliDataViewModelConverter>();
                service.AddSingleton<IAccountHistoryConverter, AccountHistoryConverter>();
                service.AddSingleton<IAccountDynamicConverter, AccountDynamicConverter>();
            }
        );
        return hostBuilder;
    }
}
