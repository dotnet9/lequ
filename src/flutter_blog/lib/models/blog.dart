class Blog {
  final String date, title, description, image;

  Blog(
      {required this.date,
      required this.title,
      required this.description,
      required this.image});
}

List<Blog> blogPosts = [
  Blog(
    date: "23 September 2020",
    image: "https://dotnet9.com/wp-content/uploads/2021/09/1-2-480x300.jpeg",
    title: "How Ireland’s biggest bank executed a comp lete security redesign",
    description:
        "Mobile banking has seen a huge increase since Coronavirus. In fact, CX platform Lightico found that 63 percent of people surveyed said they were more willing to try a new digital banking app than before the pandemic.So while you may be more inclined to bank remotely these days, cybercrime—especially targeting banks—is on the rise.",
  ),
  Blog(
    date: "21 August  2020",
    image: "https://dotnet9.com/wp-content/uploads/2021/10/a-480x300.jpeg",
    title: "5 Examples of Web Motion Design That Really Catch Your Eye",
    description:
        "Web animation has become one of the most exciting web design trends in 2020. It breathes more life into a website and makes user interactions even more appealing and intriguing. Animation for websites allows introducing a brand in an exceptionally creative way in modern digital space. It helps create a lasting impression, make a company",
  ),
  Blog(
    date: "23 September 2020",
    image: "https://dotnet9.com/wp-content/uploads/2021/09/1-2-480x300.jpeg",
    title: "The Principles of Dark UI Design",
    description:
        "Mobile banking has seen a huge increase since Coronavirus. In fact, CX platform Lightico found that 63 percent of people surveyed said they were more willing to try a new digital banking app than before the pandemic.So while you may be more inclined to bank remotely these days, cybercrime—especially targeting banks—is on the rise.",
  ),
];
