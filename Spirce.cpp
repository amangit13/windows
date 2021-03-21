#define OLC_PGE_APPLICATION
#include "olcPixelGameEngine.h"

class Source : public olc::PixelGameEngine
{

	olc::Sprite sprite;
	olc::vi2d loc = {0,0};
public:
	Source()
	{
		sAppName = "Example";
	}

public:
	bool OnUserCreate() override
	{
		//sprite = new olc::Sprite(800, 300);
		// Called once at the start, so create things here
		return true;
	}

	olc::Pixel pixel = olc::Pixel(255,255,0,255);

	bool OnUserUpdate(float fElapsedTime) override
	{
		int y = 0;
		Clear(olc::BLACK);
		// called once per frame
		for (int x = 0; x < ScreenWidth(); x++)
			//sprite->SetPixel(x, (y += (rand()) % 7 - 3) + 300, pixel);
			Draw(x, (y+=(rand())%7 -3) + 300, pixel);
		//DrawSprite(0,0, &sprite);
		return true;
	}
};


int main()
{
	Source demo;
	if (demo.Construct(800, 600, 1, 1))
		demo.Start();

	return 0;
}