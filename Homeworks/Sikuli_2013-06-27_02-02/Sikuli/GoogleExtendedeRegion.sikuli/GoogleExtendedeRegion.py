click("1372231007417.png")
sleep(2)
type("http://www.google.com" + Key.ENTER)
sleep(2)
region = find("1372241137761.png");
region.highlight();
wait(3);
new_region = Region(region.x, region.y, region.w + 300, region.h);
new_region.highlight();
wait(3);
logo = new_region.find("1372240980244.png")
click(logo)