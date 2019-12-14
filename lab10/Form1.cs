using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace lab10
{
    public partial class Form1 : Form
    {
        static float Xrot = 0.0f;
        static float Yrot = 0.0f;
        static float Zrot = 0.0f;
        static float X = 0.0f;
        static float Y = 0.0f;
        static float Z = 0.0f;
        static float XrotL = 0.0f;
        static float YrotL = 0.0f;
        static float ZrotL = 0.0f;
        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        private void triangle_Click(object sender, EventArgs e)
        {
            //произвольные точки рисуются в промежутке от координаты 0, 0 в координату 30, 30. но мы не попадем в точку правого 
            //верхнего угла, если не скорректируем координату с учетом проекции,поэтому мы умножаем на 
            //(float)AnT.Height / (float)AnT.Width или на (float)AnT.Width / (float)AnT.Height
            int glx;
            if ((float)AnT.Width <= (float)AnT.Height)
            {
                // рисуем вторую вершину в противоположенном углу 
                glx = (int)(30.0f * (float)AnT.Height / (float)AnT.Width);
            }
            else
            { // рисуем вторую вершину в противоположенном углу 
                glx = (int)(30.0f * (float)AnT.Width / (float)AnT.Height);
            }
            Random rnd = new Random();

            float r1X = (float)(rnd.Next(0, glx));
            float r2X = (float)(rnd.Next(0, glx));
            float r3X = (float)(rnd.Next(0, glx));
            float r1y = (float)(rnd.Next(0, 30));
            float r2y = (float)(rnd.Next(0, 30));
            float r3y = (float)(rnd.Next(0, 30));

            float r = (float)(rnd.Next(0, 255) / 255f);
            float g = (float)(rnd.Next(0, 255) / 255f);
            float b = (float)(rnd.Next(0, 255) / 255f);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();

            Gl.glBegin(Gl.GL_TRIANGLES);
            Gl.glColor3d(r, g, b);
            Gl.glVertex2d(r1X, r1y);
            Gl.glVertex2d(r2X, r2y);
            Gl.glVertex2d(r3X, r3y);
            Gl.glEnd();

            Gl.glFlush();
            AnT.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализация библиотеки GLUT 
            Glut.glutInit(); 
            // инициализация режима окна 
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE); 
            // устанавливаем цвет очистки окна 
            Gl.glClearColor(255, 255, 255, 1); 
            // устанавливаем порт вывода, основываясь на размерах элемента управления AnT 
            Gl.glViewport(0, 0, AnT.Width, AnT.Height); 
            // устанавливаем проекционную матрицу 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // очищаем ее Gl.glLoadIdentity(); 
            // теперь необходимо корректно настроить 2D ортогональную проекцию 
            // в зависимости от того, какая сторона больше 
            // мы немного варьируем то, как будут сконфигурированы настройки проекции 
            if (AnT.Width <= AnT.Height)
                Glu.gluOrtho2D(0.0, 30.0, 0.0, 30.0 * (float)AnT.Height / (float)AnT.Width);
            else
                Glu.gluOrtho2D(0.0, 30.0 * (float)AnT.Width / (float)AnT.Height, 0.0, 30.0); 
            // переходим к объектно-видовой матрице 
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            
        }

        private void rectangle_Click(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            int glx;
            if ((float)AnT.Width <= (float)AnT.Height)
            {// рисуем вторую вершину в противоположенном углу 
                glx = (int)(30.0f * (float)AnT.Height / (float)AnT.Width);
            }
            else
            { // рисуем вторую вершину в противоположенном углу 
                glx = (int)(30.0f * (float)AnT.Width / (float)AnT.Height);
            }
            Random rnd = new Random();
            float r = (float)(rnd.Next(0, 255) / 255f);
            float g = (float)(rnd.Next(0, 255) / 255f);
            float b = (float)(rnd.Next(0, 255) / 255f);

            float r1X = (float)(rnd.Next(0, glx / 2));
            float r2X = (float)(rnd.Next(glx / 2, glx));
            float r3X = (float)(rnd.Next(glx / 2, glx));
            float r4X = (float)(rnd.Next(0, glx / 2));
            float r1y = (float)(rnd.Next(0, 15));
            float r2y = (float)(rnd.Next(0, 15));
            float r3y = (float)(rnd.Next(15, 30));
            float r4y = (float)(rnd.Next(15, 30));

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3d(r, g, b);// устанавливаем параметр цвета, основанный на параметрах a b c 
            Gl.glVertex2d(r1X, r1y);
            Gl.glVertex2d(r2X, r2y);
            Gl.glVertex2d(r3X, r3y);
            Gl.glVertex2d(r4X, r4y);
            Gl.glEnd();// завершаем режим рисования примитивов 

            Gl.glFlush();
            AnT.Invalidate();
        }

        private void triangle_rgb_Click(object sender, EventArgs e)
        {
            //произвольные точки рисуются в промежутке от координаты 0, 0 в координату 30, 30. 
            //но мы не попадем в точку правого верхнего угла, если не скорректируем координату с учетом проекции, 
            //поэтому мы умножаем на (float)AnT.Height / (float)AnT.Width или на (float)AnT.Width / (float)AnT.Height
            int glx;
            if ((float)AnT.Width <= (float)AnT.Height)
            {
                // рисуем вторую вершину в противоположенном углу 
                glx = (int)(30.0f * (float)AnT.Height / (float)AnT.Width);
            }
            else
            { // рисуем вторую вершину в противоположенном углу 
                glx = (int)(30.0f * (float)AnT.Width / (float)AnT.Height);
            }
            Random rnd = new Random();
            float r1X = (float)(rnd.Next(0, glx));
            float r2X = (float)(rnd.Next(0, glx));
            float r3X = (float)(rnd.Next(0, glx));
            float r1y = (float)(rnd.Next(0, 30));
            float r2y = (float)(rnd.Next(0, 30));
            float r3y = (float)(rnd.Next(0, 30));

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            
            Gl.glBegin(Gl.GL_TRIANGLES);
            Gl.glColor3d(1, 0, 0);
            Gl.glVertex2d(r1X, r1y);
            Gl.glColor3d(0, 0, 1);
            Gl.glVertex2d(r2X, r2y);
            Gl.glColor3d(0, 1, 0);
            Gl.glVertex2d(r3X, r3y);
            Gl.glEnd();

            Gl.glFlush();
            AnT.Invalidate();
        }

        private void rand_fig_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int r = rnd.Next(0, 2);
            if (r == 0)
                triangle_rgb_Click(sender, e);
            else if (r == 1)
                rectangle_Click(sender, e);
            else if (r == 2)
                triangle_Click(sender, e);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);

            Glut.glutInitWindowSize(500, 500);
            Glut.glutCreateWindow("Чайник");

            Gl.glShadeModel(Gl.GL_SMOOTH);//Установите модель затенения
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            float[] light_pos = new float[3] { 1, 0.5F, 1 };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light_pos);
            Gl.glClearDepth(1.0f);//Установите значение буфера глубины (ranges[0,1])
            Gl.glEnable(Gl.GL_DEPTH_TEST);//Включить тест глубины
            Gl.glDepthFunc(Gl.GL_LEQUAL);//Если два объекта с одинаковыми координатами показывают первый нарисованный
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);

            Glut.glutReshapeFunc(reshape);//Изменение размеров окна
            Glut.glutDisplayFunc(render);//Функция перерисовки окна
            // Установить обратный вызов ключа окна
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(keyboard));
            // Установите для окна специальный обратный вызов
            Glut.glutSpecialFunc(new Glut.SpecialCallback(specialKey));
            // Установить окна для обратного вызова движения мыши
            Glut.glutMouseWheelFunc(new Glut.MouseWheelCallback(processMouseWheel));
            Glut.glutMainLoop();
        }

        void render()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();//push матрицы перед выховом glRotatef и glTranslatef
            Gl.glRotatef(Xrot, 1.0f, 0.0f, 0.0f);//Повернуть на х
            Gl.glRotatef(Yrot, 0.0f, 1.0f, 0.0f);//Повернуть на y
            Gl.glRotatef(Zrot, 0.0f, 0.0f, 1.0f);//Повернуть на z

            Gl.glTranslatef(X, Y, Z);//Переводит экран влево, вправо, вверх, вниз и масштабирование
            Glu.gluLookAt(0, 0, 0, 0, 0, 1, 0, 1, 0);

            Random rnd = new Random();
            float r = (float)(rnd.Next(0, 255) / 255f);
            float g = (float)(rnd.Next(0, 255) / 255f);
            float b = (float)(rnd.Next(0, 255) / 255f);
            Gl.glColor3d(r, g, b);// устанавливаем параметр цвета, основанный на параметрах a b c 
            Glut.glutSolidTeapot(1);

            Glut.glutPostRedisplay();//перерисовка
            Gl.glPopMatrix();//pop the Matrix
            Glut.glutSwapBuffers();
        }

        static void reshape(int w, int h)
        {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(75f, (float)w / (float)h, 0.10f, 500.0f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(XrotL, YrotL, 3f+ZrotL, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
        }

        static void processMouseWheel(int wheel, int direction, int x, int y)
        {
            Z += direction;
            Glut.glutPostRedisplay();
        }

        private static void specialKey(int key, int x, int y)
        {
            switch (key)
            {
                case Glut.GLUT_KEY_LEFT://Повернуть по оси Y
                    Yrot -= 2.0f;
                    break;
                case Glut.GLUT_KEY_RIGHT://Повернуть по оси Y
                    Yrot += 2.0f;
                    break;
                case Glut.GLUT_KEY_UP://Повернуть по оси X
                    Xrot -= 2.0f;
                    break;
                case Glut.GLUT_KEY_DOWN://Повернуть по оси X
                    Xrot += 2.0f;
                    break;
                case Glut.GLUT_KEY_PAGE_UP://Повернуть по оси Z
                    Zrot -= 2.0f;
                    break;
                case Glut.GLUT_KEY_PAGE_DOWN://Повернуть по оси Z
                    Zrot += 2.0f;
                    break;
                default:
                    break;
            }
            Glut.glutPostRedisplay();
        }

        public static void keyboard(byte key, int x, int y)
        {
            switch (key)
            {
                case 111://Resets all parameters
                case 80:
                    X = Y = 0.0f;
                    Z = 0.0f;
                    Xrot = 0.0f;
                    Yrot = 0.0f;
                    Zrot = 0.0f;
                    XrotL = 0.0f;
                    YrotL = 0.0f;
                    ZrotL = 0.0f;
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    Gl.glLoadIdentity();
                    Glu.gluLookAt(XrotL, YrotL, 3f + ZrotL,
                        0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
                    break;
            }
            Glut.glutPostRedisplay();
        }
    }
}
