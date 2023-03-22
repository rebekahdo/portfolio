//  Code for CS 211 Lab 6
//  
//    This code is pretty unimportant for Lab 6
//
//  Written by Pat Troy
//
/**  This code will represent line segments in a 2-D space.
  * 
  * This code will use the point2d.c/point2d.h code
  *    Note that the point2d code uses integer values for the X and Y corrdinates
  * 
  * So the segment structure "has a" member of the point2D structure (actually it has 2).
  */

#include "point2d.h"

const double PI = 3.14159265359;

typedef struct SegmentStruct
{
   point2d endp1;
   point2d endp2;
} segment;

   void changeEndPoint1 ( segment *s, point2d p);
   void changeEndPoint2 ( segment *s, point2d p);
   double length(segment s);
   double slope(segment s);
 
  void setEndPoints ( segment *s, point2d p1, point2d p2)
    {
	    changeEndPoint1 (s, p1);
	    changeEndPoint2 (s, p2);
    }

  void changeEndPoint1 ( segment *s, point2d p)
  {
   s->endp1 = p;
  }

  void changeEndPoint2 ( segment *s, point2d p)
  {
   s->endp2 = p;
  }


  double length(segment s)
  {
    return 0.0;
  }

  double slope(segment s)
  { 
    return 0.0;
  }


double calcAngleOfIntersection ( segment s1, segment s2)
{
 double m1 = slope(s1);
 double m2 = slope(s2);

 // note atan() return radians, so convert to degrees
 //  The angle returned is from positive x axis
 double angle1 = atan( m1 ) * 180.0 / PI ;
 double angle2 = atan( m2 ) * 180.0 / PI ;

 // note use abs( ) if you only want positive angle values
 return angle1 - angle2;
}

int main (int argc, char** argv)
{
 char buffer[100];

 point2d p1; setXY(&p1, 3, 5);
 point2d p2; setXY(&p2, -4, 2);
 
 printf ("\nCreating Segments\n"); 
 segment seg1; setEndPoints (&seg1, p1, p2);

 setXY (&p2,  7, -4 );
 segment seg2; setEndPoints (&seg2, p1, p2);

 printf ("\nInformation On Segments\n"); 
 printf ("Length of Segement1: %f\n", length(seg1) );
 printf ("Slope of Segement1: %f\n", slope(seg1) );
 printf ("Slope of Segement2: %f\n", slope(seg2) );

 // calling calcAngleOfIntersection( ) as a function
 double angle;
 angle = calcAngleOfIntersection ( seg1, seg2 );
 // calling calcAngleOfIntersection // ( ) as a method
 // angle =  seg1.calcAngleOfIntersection ( seg2 );
 printf ("Angle of Intersection: %f\n", angle );

 return 1;
}

