//
//  startAppUnity.h
//  Unity
//
//  Created by StartApp on 6/8/14.
//  Copyright (c) 2013 StartApp. All rights reserved.
//  SDK version 3.2.3_Unity

#import <UIKit/UIKit.h>
#import "STAStartAppSDK.h"
#import "STASplashPreferences.h"



@interface STAUnityBridge : NSObject 

+ (void)sdkInitilizeWithAppId:(NSString*) appId withDevId:(NSString*)devId;

//Regular ad callbacks
+(void)didLoadAd;
+(void)failedLoadAdWithError:(NSString *)error;
+(void)didShowAd;
+(void)failedShowAdWithError:(NSString *)error;
+(void)didCloseAd;
+(void)didClickAd;
+(void)didCloseInAppStore;
+(void)didCompleteVideo;

//Splash callbacks
+(void)didLoadSplashAd;
+(void)failedLoadSplashAdWithError:(NSString *)error;
+(void)didShowSplashAd;
+(void)failedShowSplashAdWithError:(NSString *)error;
+(void)didCloseSplashAd;
+(void)didClickSplashAd;
+(void)didCloseSplashInAppStore;

//Banner callbacks
+ (void) didDisplayBannerAd;
+ (void) failedLoadBannerAdWithError:(NSString *)error;
+ (void) didClickBannerAd;


@end
