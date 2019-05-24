//
//  startAppUnity.m
//  Unity
//
//  Created by StartApp on 6/8/14.
//  Copyright (c) 2013 StartApp. All rights reserved.
//  SDK version 3.2.3_Unity


#import "STAUnityBridge.h"

#import "STAUnityAd.h"
#import "STAUnityBanner.h"

@implementation STAUnityBridge

static STAUnityAd *startAppAd = [[STAUnityAd alloc]init];
static STAUnityBanner *startAppBanner = [[STAUnityBanner alloc]init];

static const char* lastAdDelegate;
static STAAdType lastAdType;
static const char* bannerDelegate;
static const char* splashDelegate;

static bool showSplash = false;
static bool showedSplash = false;


//Ad callbacks
+(void)didLoadAd
{
    _didLoadAd();
}

+(void)failedLoadAdWithError:(NSString *)error
{
    _failedLoadAd([error UTF8String]);
}

+(void)didShowAd
{
    _didShowAd();
}

+(void)failedShowAdWithError:(NSString *)error
{
    _failedShowAd([error UTF8String]);
}

+(void)didCloseAd
{
    _didCloseAd();
    //remove this line to build Unity test app
    //    [startAppAd loadAd:lastAdType];
}

+(void)didClickAd
{
    _didClickAd();
    //remove this line to build Unity test app
    //    [startAppAd loadAd:lastAdType];
}

+(void)didCloseInAppStore{
    _didCloseInAppStore();
}

+(void)didCompleteVideo{
    _didCompleteVideo();
}



//Banner callbacks
+ (void) didDisplayBannerAd{
    _didDisplayBannerAd();
}
+ (void) failedLoadBannerAdWithError:(NSString *)error{
    _failedLoadBannerAd([error UTF8String]);
}
+ (void) didClickBannerAd{
    _didClickBannerAd();
}

//initialize method
+ (void)sdkInitilizeWithAppId:(NSString*) appId withDevId:(NSString*)devId {
    STAStartAppSDK *sdk = [STAStartAppSDK sharedInstance];
    sdk.isUnityEnvironment = YES;
    sdk.appID=appId;
    sdk.devID=devId;
}

//Return ad methods
+ (void)disableReturnAd {
    STAStartAppSDK *sdk = [STAStartAppSDK sharedInstance];
    [sdk disableReturnAd];
}

+ (void)enterBackground {
    STAStartAppSDK *sdk = [STAStartAppSDK sharedInstance];
    [sdk unityAppDidEnterBackground];
}


+ (void)enterForeground{
    STAStartAppSDK *sdk = [STAStartAppSDK sharedInstance];
    [sdk unityAppWillEnterForeground];
}


//Splash ad methods
+ (void)showSplashAdWithPreferences:(STASplashPreferences *)splashPreferences{
    showSplash = true;
    STAStartAppSDK *sdk = [STAStartAppSDK sharedInstance];
    if(showSplash && ! showedSplash){
        [startAppAd showSplashAdWithPref:splashPreferences];
        showedSplash = true;
    }
    [sdk unitySDKInitialize];
}


//Splash callbacks
+(void)didLoadSplashAd
{
    _didLoadSplashAd();
}

+(void)failedLoadSplashAdWithError:(NSString *)error
{
    _failedLoadSplashAd([error UTF8String]);
}

+(void)didShowSplashAd
{
    _didShowSplashAd();
}

+(void)failedShowSplashAdWithError:(NSString *)error
{
    _failedShowSplashAd([error UTF8String]);
}

+(void)didCloseSplashAd
{
    _didCloseSplashAd();
}

+(void)didClickSplashAd
{
    _didClickSplashAd();
}

+(void)didCloseSplashInAppStore{
    _didCloseSplashInAppStore();
}


//Other methods
+ (void)setUnitySupportedOrientations:(int)supportedOrientations {
    STAStartAppSDK *sdk = [STAStartAppSDK sharedInstance];
    [sdk setUnitySupportedOrientations:supportedOrientations];
}

+ (void)setUnityAutoRotation:(int)autoRotation {
    STAStartAppSDK *sdk = [STAStartAppSDK sharedInstance];
    [sdk setUnityAutoRotation:autoRotation];
}

+ (void)setUnityVersion:(NSString *)unityVersion {
    STAStartAppSDK *sdk = [STAStartAppSDK sharedInstance];
    [sdk setUnityVersion:unityVersion];
}

extern "C" {
    
    //ad callbacks
    bool _isAdReady()
    {
        return [startAppAd isReady];
    }
    
    void _didLoadAd () {
        
        UnitySendMessage(lastAdDelegate, "didLoadAd", "");
    }
    
    void _failedLoadAd ( const char *error ) {
        
        UnitySendMessage(lastAdDelegate, "failedLoadAd", error);
    }
    
    void _didShowAd () {
        
        UnitySendMessage(lastAdDelegate, "didShowAd", "");
        //        UnitySendMessage("StartAppWrapperiOS", "lockScreen", "");
    }
    
    void _failedShowAd ( const char *error ) {
        
        UnitySendMessage(lastAdDelegate, "failedShowAd", error);
    }
    
    void _didCloseAd () {
        //        UnitySendMessage("StartAppWrapperiOS", "lockScreen", "");
        UnitySendMessage(lastAdDelegate, "didCloseAd", "");
    }
    
    void _didClickAd () {
        //        UnitySendMessage("StartAppWrapperiOS", "lockScreen", "");
        UnitySendMessage(lastAdDelegate, "didClickAd", "");
    }
    
    void _didCloseInAppStore () {
        //        UnitySendMessage("StartAppWrapperiOS", "lockScreen", "");
        UnitySendMessage(lastAdDelegate, "didCloseInAppStore", "");
    }
    
    void _didCompleteVideo () {
        //        UnitySendMessage("StartAppWrapperiOS", "lockScreen", "");
        UnitySendMessage(lastAdDelegate, "didCompleteVideo", "");
    }
    
    //Splash callbacks
    void _didLoadSplashAd () {
        
        UnitySendMessage(splashDelegate, "didLoadSplashAd", "");
    }
    
    void _failedLoadSplashAd ( const char *error ) {
        
        UnitySendMessage(splashDelegate, "failedLoadSplashAd", error);
    }
    
    void _didShowSplashAd () {
        
        UnitySendMessage(splashDelegate, "didShowSplashAd", "");
        //        UnitySendMessage("StartAppWrapperiOS", "lockScreen", "");
    }
    
    void _failedShowSplashAd ( const char *error ) {
        
        UnitySendMessage(splashDelegate, "failedShowSplashAd", error);
    }
    
    void _didCloseSplashAd () {
        //        UnitySendMessage("StartAppWrapperiOS", "lockScreen", "");
        UnitySendMessage(splashDelegate, "didCloseSplashAd", "");
    }
    
    void _didClickSplashAd () {
        //        UnitySendMessage("StartAppWrapperiOS", "lockScreen", "");
        UnitySendMessage(splashDelegate, "didClickSplashAd", "");
    }
    
    void _didCloseSplashInAppStore () {
        //        UnitySendMessage("StartAppWrapperiOS", "lockScreen", "");
        UnitySendMessage(splashDelegate, "didCloseSplashInAppStore", "");
    }
    
    //banner callbacks
    
    void _didDisplayBannerAd () {
        
        UnitySendMessage(bannerDelegate, "didDisplayBannerAd", "");
    }
    
    void _failedLoadBannerAd ( const char *error ) {
        
        UnitySendMessage(bannerDelegate, "failedLoadBannerAd", error);
    }
    
    void _didClickBannerAd () {
        
        UnitySendMessage(bannerDelegate, "didClickBannerAd", "");
    }
    
    
    //initialize methods
    void _sdkInitilize (const char* appId, const char* devId)
    {
        [STAUnityBridge sdkInitilizeWithAppId:[NSString stringWithUTF8String:appId] withDevId:[NSString stringWithUTF8String:devId]];
    }
    
    
    //Return ad methods
    void _disableReturnAd()
    {
        [STAUnityBridge disableReturnAd];
    }
    
    void _enterForeground ()
    {
        [STAUnityBridge enterForeground];
    }
    
    void _enterBackground ()
    {
        [STAUnityBridge enterBackground];
    }
    
    //Splash ad methods
    void _showSplashAd(const char* splashMode,const char* splashMinTime,const char* splashAdDisplayTime,const char* splashTemplateTheme,const char* splashLoadingIndicatorType,const char* objectDelegate,const char* splashTemplateIconImageName,const char* splashTemplateAppName, int splashLoadingIndicatorCenterPointX,int splashLoadingIndicatorCenterPointY,bool isLandscape)
    {
        char* res = (char*)malloc(strlen(objectDelegate) + 1);
        strcpy(res, objectDelegate);
        splashDelegate = res;
        
        
        STASplashPreferences *pref = [[STASplashPreferences alloc]init];
        pref.splashMode = [startAppAd getSplashModeFromChar:splashMode];
        pref.splashMinTime = [startAppAd getSplashMinTimeFromChar:splashMinTime];
        pref.splashAdDisplayTime = [startAppAd getSplashAdDisplayTimeFromChar:splashAdDisplayTime];
        pref.splashTemplateTheme = [startAppAd getSplashTemplateThemeFromChar:splashTemplateTheme];
        pref.splashLoadingIndicatorType = [startAppAd getSplashLoadingIndicatorTypeFromChar:splashLoadingIndicatorType];
        
        
        if(splashTemplateIconImageName){
            pref.splashTemplateIconImageName = [NSString stringWithUTF8String:splashTemplateIconImageName];
        }
        if(splashTemplateAppName){
            pref.splashTemplateAppName = [NSString stringWithUTF8String:splashTemplateAppName];
        }
        
        CGPoint point;
        point.x = splashLoadingIndicatorCenterPointX;
        point.y = splashLoadingIndicatorCenterPointY;
        
        if(point.x!=0 || point.y!=0){
            pref.splashLoadingIndicatorCenterPoint = point;
        }
        pref.isLandscape = isLandscape;
        [STAUnityBridge showSplashAdWithPreferences:pref];
    }
    
    
    
    //ad methods
    void _loadAd (const char* adType, const char* objectDelegate)
    {
        char* res = (char*)malloc(strlen(objectDelegate) + 1);
        strcpy(res, objectDelegate);
        lastAdDelegate = res;
        lastAdType = STAAdType_Overlay;
        
        [startAppAd loadAd:lastAdType];
    }
    
    void _loadRewardedVideoAd (const char* objectDelegate)
    {
        char* res = (char*)malloc(strlen(objectDelegate) + 1);
        strcpy(res, objectDelegate);
        lastAdDelegate = res;
        lastAdType = STAAdType_Overlay;
        
        [startAppAd loadRewardedVideoAd];
    }
    
    void _showAd ()
    {
        [startAppAd showAd];
    }
    
    //banner methods
    void _addBanner (const char* bannerType,const char* bannerPosition,const char* bannerSize, const char* objectDelegate)
    {
        char* res = (char*)malloc(strlen(objectDelegate) + 1);
        strcpy(res, objectDelegate);
        bannerDelegate = res;
        
        [startAppBanner addBannerWithSize:[startAppBanner getBannerSizeFromChar:bannerSize] autoOrigin:[startAppBanner getBannerPositionFromChar:bannerPosition]];
        
    }
    
    void _addBannerAtFixedOrigin (const char* bannerType,int x,int y,const char* bannerSize, const char* objectDelegate)
    {
        char* res = (char*)malloc(strlen(objectDelegate) + 1);
        strcpy(res, objectDelegate);
        bannerDelegate = res;
        
        [startAppBanner addBannerWithSize:[startAppBanner getBannerSizeFromChar:bannerSize] origin:CGPointMake(x,y)];
    }
    
    void _setBannerPosition(const char* bannerPosition)
    {
        [startAppBanner setBannerPosition:[startAppBanner getBannerPositionFromChar:bannerPosition]];
    }
    
    void _setBannerFixedPosition(int x,int y)
    {
        [startAppBanner setBannerFixedPosition:CGPointMake(x,y)];
    }
    void _setBannerSize(const char* bannerSize)
    {
        [startAppBanner setBannerSize:[startAppBanner getBannerSizeFromChar:bannerSize]];
    }
    
    void _didRotateFromInterfaceOrientation(int orientation)
    {
        [startAppBanner didRotateFromInterfaceOrientation:orientation];
    }
    
    void _hideBanner()
    {
        [startAppBanner hideBanner];
    }
    
    void _showBanner()
    {
        [startAppBanner showBanner];
    }
    
    bool _bannerIsVisible()
    {
        return [startAppBanner isVisible];
    }
    
    //Others methods
    
    bool _STAShouldAutoRotate()
    {
        return [startAppAd shouldAutoRotate];
    }
    
    void _setUnitySupportedOrientations(int supportedOrientations)
    {
        [STAUnityBridge setUnitySupportedOrientations:supportedOrientations];
    }
    
    void _setUnityAutoRotation(int autoRotation)
    {
        [STAUnityBridge setUnityAutoRotation:autoRotation];
    }
    
    void _setUnityVersion(const char* unityVersion)
    {
        [STAUnityBridge setUnityVersion:[NSString stringWithUTF8String:unityVersion]];
    }
}

@end
