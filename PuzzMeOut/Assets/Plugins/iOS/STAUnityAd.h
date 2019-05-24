//
//  StartAppObject.h
//  Unity
//
//  Created by StartApp on 6/8/14.
//  Copyright (c) 2013 StartApp. All rights reserved.
//  SDK version 3.2.3_Unity


#import <Foundation/Foundation.h>
#import "STAStartAppAd.h"
#import "STASplashPreferences.h"

@interface STAUnityAd : NSObject <STADelegateProtocol>

-(void)loadAd:(STAAdType) adType;
-(void)loadRewardedVideoAd;
-(void)showAd;

-(BOOL)shouldAutoRotate;
-(BOOL)isReady;


-(STAAdType) getAdTypeFromChar:(const char *)adType;
-(void)showSplashAdWithPref:(STASplashPreferences *)splashPreferences;


-(STASplashMode) getSplashModeFromChar:(const char *)splashMode;
-(STASplashMinTime) getSplashMinTimeFromChar:(const char *)splashMinTime;
-(STASplashAdDisplayTime) getSplashAdDisplayTimeFromChar:(const char *)splashAdDisplayTime;
-(STASplashTemplateTheme) getSplashTemplateThemeFromChar:(const char *)splashTemplateTheme;
-(STASplashLoadingIndicatorType) getSplashLoadingIndicatorTypeFromChar:(const char *)splashLoadingIndicatorType;



@end
