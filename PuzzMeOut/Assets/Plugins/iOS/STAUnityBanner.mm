//
//  StartAppBanner.m
//  Unity
//
//  Created by StartApp on 6/8/14.
//  Copyright (c) 2013 StartApp. All rights reserved.
//  SDK version 3.2.3_Unity

#import "STAUnityBanner.h"
#import "STAUnityBridge.h"


@implementation STAUnityBanner

STABannerView *banner;

- (id)init {
    self = [super init];
    if (self) {
    }
    return self;
}


-(void)addBannerWithSize:(STABannerSize) size autoOrigin:(STAAdOrigin) origin {
    if(banner==nil)
    {
        banner = [[STABannerView alloc]initWithSize:size autoOrigin:origin withView:[self topViewControllerWithRootViewController:[UIApplication sharedApplication].keyWindow.rootViewController].view withDelegate:self];
        
        [[self topViewControllerWithRootViewController:[UIApplication sharedApplication].keyWindow.rootViewController].view addSubview:banner];
    }
}

-(void)addBannerWithSize:(STABannerSize) size origin:(CGPoint) origin{
    if(banner==nil)
    {
        banner = [[STABannerView alloc]initWithSize:size origin:origin withView:[self topViewControllerWithRootViewController:[UIApplication sharedApplication].keyWindow.rootViewController].view withDelegate:self];
        
        [[self topViewControllerWithRootViewController:[UIApplication sharedApplication].keyWindow.rootViewController].view addSubview:banner];
    }
}

-(void)setBannerPosition:(STAAdOrigin) origin {
    if(banner==nil)
        return;
    [banner setSTAAutoOrigin:origin];
}
-(void)setBannerFixedPosition:(CGPoint) origin {
    if(banner==nil)
        return;
    [banner setOrigin:origin];
}
-(void)setBannerSize:(STABannerSize) size {
    if(banner==nil)
        return;
    [banner setSTABannerSize:size];
}


-(void)hideBanner {
    if(banner==nil)
        return;
    [banner hideBanner];
}

-(void)showBanner {
    if(banner==nil)
        return;
    [banner showBanner];
}

-(BOOL)isVisible {
    if(banner==nil)
        return NO;
    return [banner isVisible];
}


-(void)didRotateFromInterfaceOrientation:(int) orientation{
    
    if(banner!=nil)
    {
        UIInterfaceOrientation orien;
        if(orientation==0) {
            orien = UIInterfaceOrientationPortrait;
        }else if(orientation==1) {
            orien = UIInterfaceOrientationPortraitUpsideDown;
        }else if(orientation==2) {
            orien = UIInterfaceOrientationLandscapeLeft;
        }else{
            orien = UIInterfaceOrientationLandscapeRight;
        }
        [banner didRotateFromInterfaceOrientation:orien];
    }
}


//Banner callbacks
- (void) didDisplayBannerAd:(STABannerView*)banner{
    [STAUnityBridge didDisplayBannerAd];
}
- (void) failedLoadBannerAd:(STABannerView*)banner withError:(NSError *)error{
    [STAUnityBridge failedLoadBannerAdWithError:[error localizedDescription]];
}
- (void) didClickBannerAd:(STABannerView*)banner{
    [STAUnityBridge didClickBannerAd];
}







//Banner enum conversions methods
-(STABannerSize) getBannerSizeFromChar:(const char *)bannerSize{
    STABannerSize size = STA_AutoAdSize;
    if([[NSString stringWithUTF8String:bannerSize] isEqual:@"STA_PortraitAdSize_320x50"])
    {
        size=STA_PortraitAdSize_320x50;
    }else if ([[NSString stringWithUTF8String:bannerSize] isEqual:@"STA_LandscapeAdSize_480x50"]) {
        size=STA_LandscapeAdSize_480x50;
    }else if ([[NSString stringWithUTF8String:bannerSize] isEqual:@"STA_PortraitAdSize_768x90"]) {
        size=STA_PortraitAdSize_768x90;
    }else if ([[NSString stringWithUTF8String:bannerSize] isEqual:@"STA_LandscapeAdSize_1024x90"]) {
        size=STA_LandscapeAdSize_1024x90;
    }else  if ([[NSString stringWithUTF8String:bannerSize] isEqual:@"STA_AutoAdSize"]) {
        size=STA_AutoAdSize;
    }
    return size;
}


-(STAAdOrigin) getBannerPositionFromChar:(const char *)bannerPosition{
    STAAdOrigin position = STAAdOrigin_Top;
    if([[NSString stringWithUTF8String:bannerPosition] isEqual:@"TOP"])
    {
        position=STAAdOrigin_Top;
    }else if ([[NSString stringWithUTF8String:bannerPosition] isEqual:@"BOTTOM"]) {
        position=STAAdOrigin_Bottom;
    }
    return position;
}

//Other methods
- (UIViewController*)topViewControllerWithRootViewController:(UIViewController*)rootViewController {
    if ([rootViewController isKindOfClass:[UITabBarController class]]) {
        UITabBarController* tabBarController = (UITabBarController*)rootViewController;
        return [self topViewControllerWithRootViewController:tabBarController.selectedViewController];
    } else if ([rootViewController isKindOfClass:[UINavigationController class]]) {
        UINavigationController* navigationController = (UINavigationController*)rootViewController;
        return [self topViewControllerWithRootViewController:navigationController.visibleViewController];
    } else if (rootViewController.presentedViewController) {
        UIViewController* presentedViewController = rootViewController.presentedViewController;
        return [self topViewControllerWithRootViewController:presentedViewController];
    } else {
        return rootViewController;
    }
}

- (void) dealloc {
}


@end