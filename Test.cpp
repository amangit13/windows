#include "olcPixelGameEngine.h"
class Test: public olc::PixelGameEngine
{
    public:
        Test()
        {
            bool OnuserCreate() override
            {
                return true;
            }

            bool OnUserUpdate(float fElapsedTime) override
            {
                return true;
            }
        }
}

int main()
{
    Test test;
    if (test.Construct(256, 240, 4, 5))
        test.start();
    return 0;
}