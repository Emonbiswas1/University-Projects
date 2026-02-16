#include <windows.h>
#include <GL/glut.h>
#include <bits/stdc++.h>
#ifndef M_PI
#define M_PI 3.14159265358979323846
#endif

/*-------------------------------------------------------------------------------------

                            utils

--------------------------------------------------------------------------------------*/

void line(float x1, float y1, float x2, float y2)

{

    glBegin(GL_LINES);

    glVertex2f(x1, y1);

    glVertex2f(x2, y2);

    glEnd();

}

void lineLoopQuad(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)

{

    glBegin(GL_QUADS);

    glVertex2f(x1, y1);

    glVertex2f(x2, y2);

    glVertex2f(x3, y3);

    glVertex2f(x4, y4);

    glEnd();

}

void quad(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)

{

    glBegin(GL_QUADS);

    glVertex2f(x1, y1);

    glVertex2f(x2, y2);

    glVertex2f(x3, y3);

    glVertex2f(x4, y4);

    glEnd();

}

void triangle(float x1, float y1, float x2, float y2, float x3, float y3)

{

    glBegin(GL_TRIANGLES);

    glVertex2f(x1, y1);

    glVertex2f(x2, y2);

    glVertex2f(x3, y3);

    glEnd();

}

void circle(float x, float y, float radius, int segments = 100)

{

    glBegin(GL_POLYGON);

    for (int i = 0; i < segments; i++)

    {

        float theta = 2.0 * M_PI * float(i) / float(segments);

        float dx = radius * cosf(theta);

        float dy = radius * sinf(theta);

        glVertex2f(x + dx, y + dy);

    }

    glEnd();

}

/*-------------------------------------------------------------------------------
                                Global variables
---------------------------------------------------------------------------------*/
float e_cloudX = -1.2;
bool e_cloudMoving = false;
float e_boatX = -1.0;
bool e_boatMoving = false;
// ---------------- Wind ----------------
bool e_windActive = false;
float e_windAngle = 0.0;
// ---------------- Rain ----------------
#define E_MAX_DROPS 2000
bool e_rainActive = false;

float e_dropX[E_MAX_DROPS];
float e_dropY[E_MAX_DROPS];
float e_dropSpeed[E_MAX_DROPS];
int e_dropCount = 0;
// ---------------- Lightning ----------------
bool e_lightningStorm = false;   // toggled with 'l'
bool e_lightningActive = false;  // true when flashing
int e_lightningTimer = 0;        // flash duration
struct e_LightningBolt {
    float startX;
    float startY;
    int branches;
};

e_LightningBolt bolts[5];
int boltCount = 0;
// night
bool e_nightMode = false;
/*-----------------------------------------------------------------------------------
                                    objects
---------------------------------------------------------------------------------*/

/*-------------------------------------------------------------------------------

                                houses

---------------------------------------------------------------------------------*/
// River opposite
void e_house_1() //h_1

{
glColor3ub(178, 34, 34); // roof
quad(-0.1, 0.46, -0.013, 0.46, 0.01, 0.42, -0.12, 0.42);

glColor3ub(211, 211, 211); //wall
quad(-0.1, 0.42, -0.1, 0.3, -0.008, 0.3, -0.008, 0.42);

glColor3ub(64, 64, 64); //window L
quad(-0.093, 0.36, -0.073, 0.36, -0.073, 0.33, -0.093, 0.33);

glColor3ub(101, 67, 33); //door
quad(-0.07, 0.3, -0.07, 0.38, -0.04, 0.38, -0.04, 0.3);

glColor3ub(64, 64, 64); // window R
quad(-0.037, 0.36, -0.02, 0.36, -0.02, 0.33, -0.037, 0.33);

}

void e_house_2() //h_2

{
glColor3ub(154, 205, 50); //side roof
triangle(0.02, 0.36, 0.04, 0.41, 0.06, 0.36);

glColor3ub(54, 69, 79); //roof
quad(0.04, 0.41, 0.1, 0.41, 0.12, 0.36, 0.06, 0.36);

glColor3ub(245, 245, 220); //wall
quad(0.12, 0.36, 0.12, 0.3, 0.024, 0.3, 0.024, 0.36);

glColor3ub(154, 205, 50); // side wall
quad(0.024, 0.3, 0.056, 0.3, 0.056, 0.37, 0.024, 0.37);

glColor3ub(101, 67, 33); //door
quad(0.068, 0.3, 0.088, 0.3, 0.088, 0.34, 0.068, 0.34);

glColor3ub(173, 216, 230); // window R
quad(0.096, 0.34, 0.114, 0.34, 0.114, 0.324, 0.096, 0.324);

glColor3ub(173, 216, 230); //window L
quad(0.032, 0.34, 0.05, 0.34, 0.05, 0.324, 0.032, 0.324);
}

// River this side

void e_house_3() //h_3

{
glColor3ub(154, 205, 50); // side wall
quad(0.46, 0.0, 0.46, 0.1, 0.55, 0.1, 0.55, 0.0);

glColor3ub(54, 69, 79); // side roof
quad(0.405, 0.094, 0.43, 0.072, 0.503, 0.16, 0.48, 0.18);

glColor3ub(245, 245, 220); // front wall
quad(0.67, 0.1, 0.55, 0.1, 0.55, 0.0, 0.67, 0.0);

glColor3ub(54, 69, 79); //front roof
quad(0.48, 0.18, 0.57, 0.076, 0.68, 0.08, 0.64, 0.18);

glColor3ub(120, 66, 18); // door
quad(0.6, 0.0, 0.64, 0.0, 0.64, 0.06, 0.6, 0.06);

glColor3ub(173, 216, 230); // window
quad(0.48, 0.08, 0.52, 0.08, 0.52, 0.04, 0.48, 0.04);

glColor3ub(154, 205, 50); // side
triangle(0.457, 0.1, 0.503, 0.16, 0.55, 0.1);

glColor3ub(138, 51, 36); // ground
quad(0.46, 0.0, 0.67, 0.0, 0.69, -0.03, 0.44, -0.03);

}

void e_house_4() //h_4

{
glColor3ub(54, 69, 79); // side roof
quad(0.8, 0.22, 0.74, 0.14, 0.75, 0.1, 0.82, 0.19);

glColor3ub(245, 245, 220); // side wall
quad(0.78, 0.14, 0.86, 0.14, 0.86, 0.0, 0.78, 0.0);

glColor3ub(101, 67, 33); //door
quad(0.8, 0.08, 0.84, 0.08, 0.84, 0.0, 0.8, 0.0);

glColor3ub(255, 255, 0); //wall
quad(0.86, 0.14, 0.98, 0.14, 0.98, 0.0, 0.86, 0.0);

glColor3ub(54, 69, 79); //roof
quad(0.8, 0.22, 0.94, 0.22, 0.999, 0.109, 0.88, 0.112);

glColor3ub(135, 206, 235); // window L
quad(0.87, 0.08, 0.9, 0.08, 0.9, 0.04, 0.87, 0.04);

glColor3ub(135, 206, 235); // window R
quad(0.94, 0.08, 0.97, 0.08, 0.97, 0.04, 0.94, 0.04);

glColor3ub(245, 245, 220); //side wall up
triangle(0.82, 0.193, 0.86, 0.14, 0.78, 0.14);

glColor3ub(138, 51, 36); //ground
quad(0.78, 0.0, 0.98, 0.0, 1.0, -0.03, 0.76, -0.03);

}


void e_house_5() //h_5
{
glColor3ub(178, 34, 34); //  roof
quad(0.5, -0.5, 0.409, -0.477, 0.65, -0.25, 0.65, -0.325);
quad(0.65, -0.25, 0.65, -0.325, 0.8, -0.5, 0.9, -0.5);

glColor3ub(211, 211, 211); //front
triangle(0.65, -0.325, 0.8, -0.5, 0.5, -0.5);

glColor3ub(211, 211, 211); //wall
quad(0.8, -0.5, 0.5, -0.5, 0.5, -0.7, 0.8, -0.7);

glColor3ub(222, 184, 135); //ground
quad(0.5, -0.7, 0.8, -0.7, 0.84, -0.74, 0.46, -0.74);

glColor3ub(128, 0, 32);
quad(0.6, -0.7, 0.6, -0.56, 0.7, -0.56, 0.7, -0.7);

glColor3ub(70, 70, 70);
quad(0.54, -0.35, 0.54, -0.28, 0.5, -0.33, 0.5, -0.4);

}

void e_school() //sc

{
glColor3ub(255, 250, 240); // main structure
quad(-1.0, 0.04, -1.0, -0.6, -0.3, -0.6, -0.3, 0.04);

glColor3ub(222, 184, 135); //border
quad(-1.0, -0.6, -0.3, -0.6, -0.3, -0.56, -1.0, -0.56);
quad(-1.0, -0.22, -0.3, -0.22, -0.3, -0.26, -1.0, -0.26);
quad(-1.0, 0.04, -1.0, 0.08, -0.3, 0.08, -0.3, 0.04);

glColor3ub(139, 69, 19);
//Ground floor door

quad(-0.9, -0.56, -0.8, -0.56, -0.8, -0.36, -0.9, -0.36);
quad(-0.7, -0.56, -0.6, -0.56, -0.6, -0.36, -0.7, -0.36);
quad(-0.5, -0.56, -0.4, -0.56, -0.4, -0.36, -0.5, -0.36);

//1st floor door

glColor3ub(139, 69, 19);
quad(-0.9, -0.22, -0.8, -0.2, -0.8, -0.022, -0.9, -0.02);
quad(-0.7, -0.22, -0.6, -0.22, -0.6, -0.022, -0.7, -0.02);
quad(-0.5, -0.22, -0.4, -0.22, -0.4, -0.022, -0.5, -0.02);

}

void e_dry_hay() //d_h

{
glColor3ub(0, 1, 0);
quad(0.30, 0.0, 0.31, 0.0, 0.31, -0.03, 0.30, -0.03);

glColor3ub(238, 221, 130);
triangle(0.46, 0.0, 0.34, 0.18, 0.22, 0.0);

glColor3ub(0, 1, 0);
quad(0.36, 0.0, 0.37, 0.0, 0.37, -0.03, 0.36, -0.03);

}

/*-------------------------------------------------------------------------------

                                trees

---------------------------------------------------------------------------------*/
// tree opposite side

void e_tree_1() //t_1

{
glColor3ub(54, 42, 31);
quad(-0.35, 0.45, -0.3, 0.45, -0.3, 0.3, -0.35, 0.3);

// leaves (swaying)

glPushMatrix();
glTranslatef(-0.325, 0.45, 0.0);
if (e_windActive)
    glRotatef(1 * sin(e_windAngle), 0, 0, 1);
    glTranslatef(0.325, -0.45, 0.0);

glColor3ub(50, 205, 50);
triangle(-0.23, 0.4, -0.325, 0.525, -0.415, 0.4);

glColor3ub(50, 205, 50);
triangle(-0.25, 0.45, -0.325, 0.59, -0.4, 0.45);

    glPopMatrix();
}

void e_tree_2() //t_2

{
glColor3ub(54, 42, 31);
quad(-0.57, 0.45, -0.52, 0.45, -0.53, 0.3, -0.57, 0.3);

// leaves (swaying)

glPushMatrix();
glTranslatef(-0.325, 0.45, 0.0);
if (e_windActive)
    glRotatef(1 * sin(e_windAngle), 0, 0, 1);
    glTranslatef(0.325, -0.45, 0.0);

glColor3ub(50, 205, 50);
triangle(-0.625, 0.45, -0.475, 0.45, -0.55, 0.61);

glColor3ub(50, 205, 50);
triangle(-0.64, 0.4, -0.46, 0.4, -0.55, 0.54);

    glPopMatrix();
}

void e_tree_3() //t_3

{
glColor3ub(54, 42, 31);
quad(-0.94, 0.42, -0.9, 0.42, -0.9, 0.3, -0.94, 0.3);

// leaves (swaying)

glPushMatrix();
glTranslatef(-0.325, 0.45, 0.0);
if (e_windActive)
    glRotatef(1 * sin(e_windAngle), 0, 0, 1);
    glTranslatef(0.325, -0.45, 0.0);

glColor3ub(50, 205, 50);
circle(-0.95, 0.43, -0.04);
glColor3ub(50, 205, 50);
circle(-0.89, 0.43, -0.04);
glColor3ub(50, 205, 50);
circle(-0.92, 0.49, -0.035);

    glPopMatrix();
}
void e_tree_4() //t_4
{
glColor3ub(54, 42, 31);
quad(0.15, 0.3, 0.2, 0.3, 0.2, 0.45, 0.15, 0.45);

// leaves (swaying)

glPushMatrix();
glTranslatef(-0.325, 0.45, 0.0);
if (e_windActive)
    glRotatef(1 * sin(e_windAngle), 0, 0, 1);
    glTranslatef(0.325, -0.45, 0.0);

glColor3ub(50, 205, 50);
triangle(0.25, 0.45, 0.1, 0.45, 0.175, 0.6);
glColor3ub(50, 205, 50);
triangle(0.075, 0.4, 0.275, 0.4, 0.175, 0.5);

    glPopMatrix();
}

void e_tree_5() //t_5

{
glColor3ub(54, 42, 31);
quad(0.35, 0.3, 0.4, 0.3, 0.4, 0.45, 0.35, 0.45);

// leaves (swaying)

glPushMatrix();
glTranslatef(-0.325, 0.45, 0.0);
if (e_windActive)
    glRotatef(1 * sin(e_windAngle), 0, 0, 1);
    glTranslatef(0.325, -0.45, 0.0);

glColor3ub(50, 205, 50);
triangle(0.275, 0.4, 0.475, 0.4, 0.375, 0.5);
glColor3ub(50, 205, 50);
triangle(0.3, 0.45, 0.45, 0.45, 0.375, 0.6);

    glPopMatrix();
}

// Tree from this side

void e_tree_6() //t_6
{
glColor3ub(54, 42, 31);
quad(0.52, 0.18, 0.52, 0.24, 0.56, 0.24, 0.56, 0.18);

glColor3ub(54, 42, 31);
quad(0.5, 0.26, 0.5, 0.24, 0.52, 0.22, 0.54, 0.24);
glColor3ub(54, 42, 31);
quad(0.56, 0.22, 0.58, 0.24, 0.58, 0.26, 0.54, 0.24);

// leaves (swaying)

glPushMatrix();
glTranslatef(-0.325, 0.45, 0.0);
if (e_windActive)
    glRotatef(1 * sin(e_windAngle), 0, 0, 1);
    glTranslatef(0.325, -0.45, 0.0);

glColor3ub(50, 205, 50);
circle(0.49, 0.225, 0.03);
glColor3ub(50, 205, 50);
circle(0.48, 0.26, 0.03);
glColor3ub(50, 205, 50);
circle(0.505, 0.30, 0.05);
glColor3ub(50, 205, 50);
circle(0.55, 0.32, 0.07);
glColor3ub(50, 205, 50);
circle(0.6, 0.29, 0.05);
glColor3ub(50, 205, 50);
circle(0.605, 0.237, 0.03);

    glPopMatrix();
}

void e_tree_7() //t_7
{
    glColor3ub(54, 42, 31);
    quad(0.76, 0.24, 0.78, 0.24, 0.8, 0.22, 0.786, 0.202);

// leaves (swaying)

glPushMatrix();
glTranslatef(-0.325, 0.45, 0.0);
if (e_windActive)
    glRotatef(1 * sin(e_windAngle), 0, 0, 1);
    glTranslatef(0.325, -0.45, 0.0);

glColor3ub(50, 205, 50);
circle(0.74, 0.26, 0.05);
glColor3ub(50, 205, 50);
circle(0.775, 0.30, 0.05);
glColor3ub(50, 205, 50);
circle(0.8, 0.28, 0.05);

    glPopMatrix();

glColor3ub(54, 42, 31);
quad(0.84, 0.22, 0.86, 0.27, 0.874, 0.27, 0.86, 0.22);

// leaves (swaying)

glPushMatrix();
glTranslatef(-0.325, 0.45, 0.0);
if (e_windActive)
    glRotatef(1 * sin(e_windAngle), 0, 0, 1);
    glTranslatef(0.325, -0.45, 0.0);

glColor3ub(50, 205, 50);
circle(0.85, 0.30, 0.04);
glColor3ub(50, 205, 50);
circle(0.9, 0.32, 0.07);
glColor3ub(50, 205, 50);
circle(0.9, 0.27, 0.04);

    glPopMatrix();
}

// beside school

void e_tree_8() //t_8
{
glColor3ub(54, 42, 31);
quad(-0.72, -0.6, -0.68, -0.6, -0.68, -0.2, -0.72, -0.2);
triangle(-0.72, -0.24, -0.72, -0.2, -0.78, -0.19);
triangle(-0.68, -0.24, -0.68, -0.2, -0.62, -0.19);

// leaves (swaying)

glPushMatrix();
glTranslatef(-0.325, 0.45, 0.0);
if (e_windActive)
    glRotatef(1 * sin(e_windAngle), 0, 0, 1);
    glTranslatef(0.325, -0.45, 0.0);

glColor3ub(50, 205, 50);
circle(-0.82, -0.2, 0.07);
circle(-0.8, -0.12, 0.08);
circle(-0.74, -0.08, 0.1);
circle(-0.66, -0.08, 0.1);
circle(-0.6, -0.1, 0.07);
circle(-0.58, -0.2, 0.07);

    glPopMatrix();
}

// beside school

void e_tree_9() //t_9
{
glColor3ub(54, 42, 31);
quad(-0.3, -0.5, -0.26, -0.5, -0.26, -0.2, -0.3, -0.2);

// leaves (swaying)

glPushMatrix();
glTranslatef(-0.325, 0.45, 0.0);
if (e_windActive)
    glRotatef(1 * sin(e_windAngle), 0, 0, 1);
    glTranslatef(0.325, -0.45, 0.0);

glColor3ub(50, 205, 50);
triangle(-0.4, -0.28, -0.14, -0.28, -0.28, -0.15);
triangle(-0.38, -0.2, -0.15, -0.2, -0.275, -0.08);

    glPopMatrix();
}
//Mountain river opposite

void e_mountain_1() //m_1
{
glColor3ub(178, 161, 145);
triangle(-0.6, 0.3, -0.3, 0.3, -0.45, 0.6);
}


void e_mountain_2() //m_2
{
glColor3ub(178, 161, 145);
triangle(-0.64, 0.3, -0.86, 0.3, -0.75, 0.6);
}

void e_mountain_3() //m_3
{
glColor3ub(178, 161, 145);
triangle(0.6, 0.3, 0.9, 0.3, 0.75, 0.6);
}

void e_mountain_4() //m_4
{
glColor3ub(178, 161, 145);
triangle(0.4, 0.3, 0.7, 0.3, 0.55, 0.6);
}

void e_sky() //sk
{
    if (e_lightningActive) {
        glColor3ub(255, 255, 255);  // flash white
    }
    else if (e_nightMode) {
        glColor3ub(15, 15, 40);     // dark night sky
    }
    else {
        glColor3ub(135, 206, 235);   // normal
    }
    quad(1.0, 0.3, 1.0, 1.0, -1.0, 1.0, -1.0, 0.3);
}



void e_river() //ri

{
glColor3ub(64, 164, 223);
quad(-1.0, 0.3, -1.0, 0.0, 1.0, 0.0, 1.0, 0.3);
glColor3ub(101, 67, 33);
triangle(-0.4, 0.0, 0.1, 0.0, -0.14, 0.06);
glColor3ub(101, 67, 33);//opposite
glLineWidth(5.0f);
line(-1.0, 0.295, 1.0, 0.295);

}

void e_ground() //g

{

glColor3ub(112, 153, 83);
quad(1.0, 0.0, 1.0, -1.0, -1.0, -1.0, -1.0, 0.0);
}

void e_tubewell() //t_w

{
glColor3ub(255, 178, 102);
circle(0.859,-0.2,0.0980);

glColor3ub(37, 66, 32);
circle(0.859,-0.2,0.0880);

glColor3ub(138, 51, 36);
quad(0.856, -0.07, 0.856, -0.08, 0.814, -0.082, 0.816, -0.096);
quad(0.856, -0.09, 0.856, -0.074, 0.864, -0.074, 0.864, -0.09);
quad(0.85, -0.09, 0.87, -0.09, 0.87, -0.17, 0.85, -0.17);
quad(0.856, -0.17, 0.856, -0.2, 0.864, -0.2, 0.864, -0.17);
quad(0.87, -0.1, 0.87, -0.113, 0.89, -0.113, 0.89, -0.1);
quad(0.88, -0.1, 0.88, -0.12, 0.89, -0.12, 0.89, -0.1);

glColor3ub(127, 255, 212); //  water
quad(0.88, -0.12, 0.89, -0.12, 0.90, -0.2, 0.87, -0.2);


}

void e_road() //rd
{
glColor3ub(193, 154, 107); //ground
quad(0.57, -0.03, 0.82, -0.03, 0.6, -0.4, 0.4, -0.2);
quad(0.6, -0.4, 0.4, -0.2, 0.0, -0.5, 0.0, -0.8);
quad(0.0, -0.5, 0.0, -0.8, -0.4, -0.9, -0.4, -0.64);
quad(-0.4, -0.9, -0.4, -0.64, -1.0, -0.8, -1.0, -1.0);

}

void e_clothHanger() //c_h
{
glColor3ub(193, 154, 107);
quad(0.05, -0.1, 0.06, -0.1, 0.06, -0.3, 0.05, -0.3);
quad(0.24, -0.1, 0.25, -0.1, 0.25, -0.3, 0.24, -0.3);
quad(0.05, -0.1, 0.05, -0.11, 0.25, -0.11, 0.25, -0.1);

glPushMatrix();
glTranslatef(-0.325, 0.45, 0.0);
if (e_windActive)
    glRotatef(1 * sin(e_windAngle), 0, 0, 1);
    glTranslatef(0.325, -0.45, 0.0);

glColor3ub(245, 245, 220); // cloth1
quad(0.07, -0.1, 0.07, -0.19, 0.13, -0.19, 0.13, -0.1);

glColor3ub(70, 130, 180); //cloth2
quad(0.16, -0.1, 0.16, -0.19, 0.22, -0.19, 0.22, -0.1);
 glPopMatrix();

}

void e_cloud_1() //cl_1
{
    if (e_lightningStorm)
    {
        glColor3ub(180, 180, 180);
    }
    else
glColor3ub(230, 235, 240); // Cloud 1
circle(-0.8, 0.78, 0.08);
circle(-0.9, 0.78, 0.07);
circle(-0.7, 0.78, 0.07);
circle(-0.85, 0.83, 0.06);
circle(-0.75, 0.83, 0.06);
circle(-0.8, 0.86, 0.05);

}

void e_cloud_2() //cl_2

{
    if (e_lightningStorm)
    {
        glColor3ub(180, 180, 180);
    }
    else
glColor3ub(230, 235, 240);
circle(-0.4, 0.72, 0.09);
circle(-0.5, 0.72, 0.08);
circle(-0.3, 0.72, 0.08);
circle(-0.45, 0.77, 0.07);
circle(-0.35, 0.77, 0.07);
circle(-0.4, 0.80, 0.06);
}

void e_cloud_3() //cl_3
{
    if (e_lightningStorm)
    {
        glColor3ub(180, 180, 180);
    }
    else
glColor3ub(230, 235, 240);
circle(0.0, 0.70, 0.09);
circle(-0.1, 0.70, 0.08);
circle(0.1, 0.70, 0.08);
circle(-0.05, 0.75, 0.07);
circle(0.05, 0.75, 0.07);
circle(0.0, 0.78, 0.06);
}
void e_cloud_4() //cl_4
{

    if (e_lightningStorm)
    {
        glColor3ub(180, 180, 180);
    }
    else
glColor3ub(230, 235, 240);
circle(0.45, 0.80, 0.09);
circle(0.35, 0.80, 0.08);
circle(0.55, 0.80, 0.08);
circle(0.40, 0.85, 0.07);
circle(0.50, 0.85, 0.07);
circle(0.45, 0.88, 0.06);
}

void e_cloud_5() //cl_5
 {
    if (e_lightningStorm)
    {
        glColor3ub(180, 180, 180);
    }
    else
glColor3ub(230, 235, 240);
circle(0.8, 0.70, 0.08);
circle(0.7, 0.70, 0.07);
circle(0.9, 0.70, 0.07);
circle(0.75, 0.75, 0.06);
circle(0.85, 0.75, 0.06);
circle(0.8, 0.78, 0.05);

}
void e_boat_1() //b_1
{
glColor3ub(0, 0, 0);
quad(-0.74, 0.16, -0.7, 0.1, -0.55, 0.1, -0.51, 0.16);

glColor3ub(255, 250, 240);
triangle(-0.69, 0.16, -0.56, 0.16, -0.625, 0.25);
}
void e_boat_2() //b_2
{
glColor3ub(101, 67, 33);
quad(-0.25, 0.15, -0.1, 0.15, -0.118, 0.21, -0.232, 0.21);

glColor3ub(0, 0, 0);
quad(-0.25, 0.15, -0.1, 0.15, -0.1, 0.1, -0.25, 0.1);
triangle(-0.25, 0.1, -0.25, 0.15, -0.318, 0.17);
triangle(-0.1, 0.15, -0.1, 0.1, -0.034, 0.17);

}
// day night transition
void e_sun() //sn
{
    if (!e_lightningStorm)
    {
        if (e_nightMode) {
            glColor3ub(240, 240, 240);  // white moon
        }
        else {
            glColor3ub(255, 223, 0);    // yellow sun
        }
        circle(0.16, 0.91, 0.08);
    }
}

void e_national_flag() //n_f
{
glColor3ub(192, 192, 192);//pole
glLineWidth(5.0f);
line(-0.24, -0.56, -0.24, 0.06);

//flag
glPushMatrix();
glTranslatef(-0.325, 0.45, 0.0);
if (e_windActive)
    glRotatef(1 * sin(e_windAngle), 0, 0, 1);
    glTranslatef(0.325, -0.45, 0.0);

glColor3ub(0, 106, 78);
quad(-0.24, 0.06, 0.0, 0.06, 0.0, -0.14, -0.24, -0.14);
glColor3ub(244, 42, 65);
circle(-0.12, -0.03, 0.05);

glPopMatrix();

}

// rain
void e_drawRain() //d_r
{
    if (!e_rainActive) return;

    glColor3ub(200, 220, 230); // bluish raindrops
    for (int i = 0; i < e_dropCount; i++) {
        glBegin(GL_LINES);
        glVertex2f(e_dropX[i], e_dropY[i]);
        glVertex2f(e_dropX[i], e_dropY[i] - 0.05f);
        glEnd();
    }
}
/*-------------------------------------------------------------------------------
                    Emon - Summer season animations
---------------------------------------------------------------------------------*/
// e_cloud_animation
void e_cloud_anim(int val)
{
    if (e_cloudMoving) {
        e_cloudX += 0.002;
        if (e_cloudX > 1.5)
        {
            e_cloudX = -1.5;
        }
        glutPostRedisplay();
    }
    glutTimerFunc(20, e_cloud_anim, 0);
}
// e_boat_animation
void e_boat_anim(int val)
{
    if (e_boatMoving) {
        e_boatX -= 0.005;
        if (e_boatX < -1.0) {
            e_boatX = 1.5 ;
        }
        glutPostRedisplay();
    }
    glutTimerFunc(60, e_boat_anim, 0);
}
// e_rain_animation
void e_rainUpdate(int value) {
    if (e_rainActive) {
        // Add new drop randomly
        if (e_dropCount < E_MAX_DROPS && (rand() % 2) == 0) {
            e_dropX[e_dropCount] = (rand() % 2000 / 1000.0) - 1.0; // -2 to +2
            e_dropY[e_dropCount] = 2.0; // start at top
            e_dropSpeed[e_dropCount] = 0.01 + (rand() % 100 / 10000.0);
            e_dropCount++;
        }

        // Update raindrops
        for (int i = 0; i < e_dropCount; ) {
            e_dropY[i] -= e_dropSpeed[i];
            if (e_dropY[i] < -2.0) {
                // Remove drop by swapping with last
                e_dropX[i] = e_dropX[e_dropCount - 1];
                e_dropY[i] = e_dropY[e_dropCount - 1];
                e_dropSpeed[i] = e_dropSpeed[e_dropCount - 1];
                e_dropCount--;
            }
            else {
                i++;
            }
        }
    }

    glutPostRedisplay();
    glutTimerFunc(16, e_rainUpdate, 0); // ~60 FPS
}
// e_wind_animation
void e_wind_anim(int value) {
    if (e_windActive) {
        e_windAngle += 0.1; // speed of sway
        if (e_windAngle > 2 * M_PI) e_windAngle -= 2 * M_PI;
        glutPostRedisplay();
    }
    glutTimerFunc(30, e_wind_anim, 0); // refresh ~33 FPS
}
// e_lightning_animation

void e_lightning_anim(int val)
{
    if (e_lightningStorm) {
        if (!e_lightningActive && (rand() % 200 == 0)) {
            e_lightningActive = true;
            e_lightningTimer = 10;

            boltCount = 1 + rand() % 3; // 1–3 bolts
            for (int i = 0; i < boltCount; i++) {
                bolts[i].startX = -1.0 + (rand() % 200) / 100.0;
                bolts[i].startY = 1.0;
                bolts[i].branches = 1;
            }
        }

        if (e_lightningActive) {
            e_lightningTimer--;
            if (e_lightningTimer <= 0) {
                e_lightningActive = false;
                boltCount = 0;
            }
        }
    }
    glutPostRedisplay();
    glutTimerFunc(20, e_lightning_anim, 0);
}
/*-------------------------------------------------------------------------------
                                  e (emon) events
---------------------------------------------------------------------------------*/
// e_master_key_events
void e_master_key_events(unsigned char key, int x, int y)
{  // Rain
    if (key == 'r') {
        e_rainActive = !e_rainActive;
    }
    if (key == 'p') {
        e_rainActive =false;
    }
    // Wind
    if (key == 'w') {
        e_windActive = !e_windActive;
    }
    if (key == 's') {
        e_windActive =false;
    }
    //Boat
    if (key == 'b') {
        e_boatMoving = true;
    }
    if (key == 'n') {
        e_boatMoving = false;
    }
    //Cloud
    if (key == 'c') {
        e_cloudMoving = true;
    }
    if (key == 'm') {
        e_cloudMoving = false;
    }

}
void e_mouse(int button, int state, int x, int y)
{
    if (button == GLUT_LEFT_BUTTON && state == GLUT_DOWN) {
        e_nightMode = !e_nightMode;  // toggle night
        glutPostRedisplay();
    }
    else if (button == GLUT_RIGHT_BUTTON && state == GLUT_DOWN) {
        e_lightningStorm = !e_lightningStorm; // toggle lightning
        glutPostRedisplay();
    }
}
/*-------------------------------------------------------------------------------
                                   main
---------------------------------------------------------------------------------*/
void e_boats() //b_animation
{
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
    glPushMatrix();
    glTranslatef(e_boatX, 0.0f, 0.0f);
    e_boat_1();
    e_boat_2();
    glPopMatrix();
}
void e_clouds() //cl_animation
{

    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();
    glPushMatrix();
    glTranslatef(e_cloudX, 0.0f, 0.0f);

    e_cloud_1();
    e_cloud_2();
    e_cloud_3();
    e_cloud_4();
    e_cloud_5();
    glPopMatrix();
}
void e_display() {

glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
glClear(GL_COLOR_BUFFER_BIT);

e_sky();
e_clouds();
e_ground();
e_river();
e_boats();
e_house_1();
e_house_2();
e_tree_4();
e_tree_5();
e_tree_1();
e_tree_2();
e_mountain_1();
e_mountain_2();
e_mountain_3();
e_mountain_4();
e_tree_3();
e_dry_hay();
e_house_3();
e_house_4();
e_road();
e_house_5();
e_tree_6();
e_tree_7();
e_tubewell();
e_clothHanger();
e_sun();
e_tree_9();
e_school();
e_national_flag();
e_tree_8();
e_drawRain();
if (e_lightningActive)
{
 glColor4f(1.0f, 1.0f, 1.0f, 0.6f); // white overlay with alpha
    glBegin(GL_QUADS);
    glVertex2f(-1, -1);
    glVertex2f(1, -1);
    glVertex2f(1, 1);
    glVertex2f(-1, 1);
    glEnd();
}

if (e_nightMode)
{
  glColor4f(0.0f, 0.0f, 0.0f, 0.3f); // semi-transparent black
    glBegin(GL_QUADS);
    glVertex2f(-1, -1);   // bottom-left
    glVertex2f(1, -1);    // bottom-right
    glVertex2f(1, 1);  // up to the bottom of sky
    glVertex2f(-1, 1); // bottom of sky, left
    glEnd();
}

glFlush();

}

int main(int argc, char** argv)
{

glutInit(&argc, argv);
glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
glutInitWindowSize(820, 620);
glutInitWindowPosition(50, 50);
glutCreateWindow("Summer Season by Emon");
gluOrtho2D(-1, 1, -1, 1);
    /*------------------------
         Function-emon
    --------------------------*/
// e_scene
glutDisplayFunc(e_display);

// e_key_events
glutKeyboardFunc(e_master_key_events);

// e_timer

glutTimerFunc(60, e_boat_anim, 0);
glutTimerFunc(20, e_cloud_anim, 0);
srand((unsigned)time(0)); // random seed
glutTimerFunc(0, e_rainUpdate, 0);
glutTimerFunc(0, e_wind_anim, 0);
glutTimerFunc(20, e_lightning_anim, 0);
glutMouseFunc(e_mouse);

glEnable(GL_BLEND);
glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
glutMainLoop();

return 0;

}
