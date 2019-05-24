//
//  StartAppBanner.h
//  Unity
//
//  Created by StartApp on 6/8/14.
//  Copyright (c) 2013 StartApp. All rights reserved.
//  SDK version 3.2.3_Unity



#import <Foundation/Foundation.h>
#import "STABannerView.h"
#import "STABannerSize.h"


@interface STAUnityBanner : NSObject <STABannerDelegateProtocol>

-(void)addBannerWithSize:(STABannerSize) size autoOrigin:(STAAdOrigin) origin;
-(void)addBannerWithSize:(STABannerSize) size origin:(CGPoint) origin;

-(void)setBannerPosition:(STAAdOrigin) origin;
-(void)setBannerFixedPosition:(CGPoint) origin;
-(void)setBannerSize:(STABannerSize) size;
-(void)didRotateFromInterfaceOrientation:(int) orientation;


-(STABannerSize) getBannerSizeFromChar:(const char *)bannerSize;
-(STAAdOrigin) getBannerPositionFromChar:(const char *)bannerPosition;

-(void)hideBanner;
-(void)showBanner;
-(BOOL)isVisible;
@end
