//
//  StartAppObject.m
//  Unity
//
//  Created by StartApp on 6/8/14.
//  Copyright (c) 2013 StartApp. All rights reserved.
//  SDK version 3.2.3_Unity



#import "STAUnityAd.h"
#import "STAUnityBridge.h"

// macro for retrieving boolean for system version
#define SYSTEM_VERSION_LESS_THAN(v)                 ([[[UIDevice currentDevice] systemVersion] compare:v options:NSNumericSearch] == NSOrderedAscending)


@interface STAUnityAd ()
{
    STAStartAppAd *startAppAd;
}
@end

@implementation STAUnityAd

- (id)init {
    self = [super init];
    if (self) {
        startAppAd = [[STAStartAppAd alloc]init];
    }
    return self;
}


-(void)loadAd:(STAAdType) adType {
    [startAppAd loadAdWithDelegate:self];
}

-(void)loadRewardedVideoAd{
    [startAppAd loadRewardedVideoAdWithDelegate:self];
}

-(void)showAd{
    [startAppAd showAd];
}


-(BOOL)shouldAutoRotate{
    return startAppAd.STAShouldAutoRotate;
}

-(BOOL)isReady{
    return startAppAd.isReady;
}




//StartApp ad callbacks
-(void)didLoadAd:(STAAbstractAd *)ad{
    if(ad == startAppAd){
        [STAUnityBridge didLoadAd];
    }else {
        [STAUnityBridge didLoadSplashAd];
    }
}
- (void) failedLoadAd:(STAAbstractAd*)ad withError:(NSError *)error{
    if(ad == startAppAd){
        [STAUnityBridge failedLoadAdWithError:[error localizedDescription]];
    }else {
        [STAUnityBridge failedLoadSplashAdWithError:[error localizedDescription]];
    }
}
- (void) didShowAd:(STAAbstractAd*)ad{
    if(ad == startAppAd){
        [STAUnityBridge didShowAd];
    }else {
        [STAUnityBridge didShowSplashAd];
    }
}
- (void) failedShowAd:(STAAbstractAd*)ad withError:(NSError *)error{
    if(ad == startAppAd){
        [STAUnityBridge failedShowAdWithError:[error localizedDescription]];
    }else {
        [STAUnityBridge failedShowSplashAdWithError:[error localizedDescription]];
    }
}
- (void) didCloseAd:(STAAbstractAd*)ad{
    if(ad == startAppAd){
        [STAUnityBridge didCloseAd];
    }else {
        [STAUnityBridge didCloseSplashAd];
    }
}

- (void) didClickAd:(STAAbstractAd*)ad{
    if(ad == startAppAd){
        [STAUnityBridge didClickAd];
    }else {
        [STAUnityBridge didClickSplashAd];
    }
}

-(void)didCloseInAppStore:(STAAbstractAd *)ad{
    if(ad == startAppAd){
        [STAUnityBridge didCloseInAppStore];
    }else {
        [STAUnityBridge didCloseSplashInAppStore];
    }
}
-(void)didCompleteVideo:(STAAbstractAd *)ad{
    if(ad == startAppAd){
        [STAUnityBridge didCompleteVideo];
    }
}

-(STAAdType) getAdTypeFromChar:(const char *)adType{
    return STAAdType_Overlay;
}



-(void)showSplashAdWithPref:(STASplashPreferences *)splashPreferences{
    STAStartAppSDK *sdk = [STAStartAppSDK sharedInstance];
    [sdk showSplashAdWithDelegate:self withPreferences:splashPreferences];
}


//Splash enum conversion methods
-(STASplashMode) getSplashModeFromChar:(const char *)splashMode{
    STASplashMode mode = STASplashModeUserDefined;
    
    if([[NSString stringWithUTF8String:splashMode] isEqual:@"STASplashModeUserDefined"]){
        mode=STASplashModeUserDefined;
    }else if([[NSString stringWithUTF8String:splashMode] isEqual:@"STASplashModeTemplate"]){
        mode=STASplashModeTemplate;
    }
    return mode;
}


-(STASplashMinTime) getSplashMinTimeFromChar:(const char *)splashMinTime{
    STASplashMinTime minTime = STASplashMinTimeShort;
    
    if([[NSString stringWithUTF8String:splashMinTime] isEqual:@"STASplashMinTimeShort"]){
        minTime=STASplashMinTimeShort;
    }else if ([[NSString stringWithUTF8String:splashMinTime] isEqual:@"STASplashMinTimeRegular"]) {
        minTime=STASplashMinTimeRegular;
    }else if ([[NSString stringWithUTF8String:splashMinTime] isEqual:@"STASplashMinTimeLong"]) {
        minTime=STASplashMinTimeLong;
    }
    
    return minTime;
}


-(STASplashAdDisplayTime) getSplashAdDisplayTimeFromChar:(const char *)splashAdDisplayTime{
    STASplashAdDisplayTime adDisplayTime = STASplashAdDisplayTimeShort;
    
    if([[NSString stringWithUTF8String:splashAdDisplayTime] isEqual:@"STASplashAdDisplayTimeShort"]){
        adDisplayTime=STASplashAdDisplayTimeShort;
    }else if ([[NSString stringWithUTF8String:splashAdDisplayTime] isEqual:@"STASplashAdDisplayTimeLong"]) {
        adDisplayTime=STASplashAdDisplayTimeLong;
    }else if ([[NSString stringWithUTF8String:splashAdDisplayTime] isEqual:@"STASplashAdDisplayTimeForEver"]) {
        adDisplayTime=STASplashAdDisplayTimeForEver;
    }
    
    return adDisplayTime;
}


-(STASplashTemplateTheme) getSplashTemplateThemeFromChar:(const char *)splashTemplateTheme{
    STASplashTemplateTheme templateTheme = STASplashTemplateThemeDeepBlue;
    
    if([[NSString stringWithUTF8String:splashTemplateTheme] isEqual:@"STASplashTemplateThemeDeepBlue"]){
        templateTheme=STASplashTemplateThemeDeepBlue;
    }else if ([[NSString stringWithUTF8String:splashTemplateTheme] isEqual:@"STASplashTemplateThemeSky"]) {
        templateTheme=STASplashTemplateThemeSky;
    }else if ([[NSString stringWithUTF8String:splashTemplateTheme] isEqual:@"STASplashTemplateThemeAshenSky"]) {
        templateTheme=STASplashTemplateThemeAshenSky;
    }else if ([[NSString stringWithUTF8String:splashTemplateTheme] isEqual:@"STASplashTemplateThemeBlaze"]) {
        templateTheme=STASplashTemplateThemeBlaze;
    }else  if ([[NSString stringWithUTF8String:splashTemplateTheme] isEqual:@"STASplashTemplateThemeGloomy"]) {
        templateTheme=STASplashTemplateThemeGloomy;
    }else  if ([[NSString stringWithUTF8String:splashTemplateTheme] isEqual:@"STASplashTemplateThemeOcean"]) {
        templateTheme=STASplashTemplateThemeOcean;
    }
    
    return templateTheme;
}


-(STASplashLoadingIndicatorType) getSplashLoadingIndicatorTypeFromChar:(const char *)splashLoadingIndicatorType{
    STASplashLoadingIndicatorType loadingIndicatorType = STASplashLoadingIndicatorTypeIOS;
    
    if([[NSString stringWithUTF8String:splashLoadingIndicatorType] isEqual:@"STASplashLoadingIndicatorTypeIOS"]){
        loadingIndicatorType=STASplashLoadingIndicatorTypeIOS;
    }else if ([[NSString stringWithUTF8String:splashLoadingIndicatorType] isEqual:@"STASplashLoadingIndicatorTypeDots"]) {
        loadingIndicatorType=STASplashLoadingIndicatorTypeDots;
    }
    
    return loadingIndicatorType;
}


- (void) dealloc {
    
}


@end