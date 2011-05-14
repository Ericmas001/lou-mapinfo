using System;
using System.Drawing;
using System.IO;
using System.Globalization;
using System.Security;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace LouMapInfoApp
{
   /// <summary>
   ///   Provides information and serialization of user options.
   /// </summary>
   /// <remarks>
   ///   Use the <b>UserOptions</b> to set and <see cref="Save"/>
   ///   options that are specific to a user.  To access an option always use the <see cref="Current"/>
   ///   property, which returns an instance of the class.  For example <c>UserOptions.Current.StartLocation</c>.
   ///   <para>
   ///   All the properties of <b>UserOptions</b> are maintained in an XML file.  The path
   ///   to the XML file is
   ///   "<see cref="Environment.SpecialFolder">ApplicationData</see>\
   ///    <see cref="Application.CompanyName"/>\ 
   ///    <see cref="Application.ProductName"/>\ 
   ///    <i>appname</i>.options.xml".
   ///    A typical path is
   ///    "C:\Documents and Settings\<i>username</i>\Application Data\<i>company</i>\<i>product</i>\<i>appname</i>.exe.options.xml".
   ///    </para>
   ///    <para>
   ///    If security policy does not allow access to the <see cref="Environment.SpecialFolder">ApplicationData</see>
   ///    folder, then the <b>UserOptions</b> are only maintained during the lifetime of the application.
   ///    </para>
   /// </remarks>
   public class UserOptions
   {
       private bool m_bbCode_u = true;
       private bool m_bbCode_s = true;
       private bool m_bbCode_i = true;
       private bool m_bbCode_b = true;
       private bool m_bbCode_url = true;
       private bool m_bbCode_city = false;
       private bool m_bbCode_player = true;
       private bool m_bbCode_alliance = true;

       private string m_liveUsername;
       private string m_livePassword;
       private string m_liveWorld;
       private bool m_liveRememberMail = true;
       private bool m_liveRememberPass = true;

       private string m_zeusUsername;
       private string m_zeusPassword;
       private string m_zeusWorld;

       private int m_apUseSlots = 100;
       private int m_apNumCottages = 10;
       private bool m_apKeepExtraResNodes = true;
       private bool m_apClearBuildings = true;
       private bool m_apBuildOnlyOnOpen = false;
       private string m_apPlacementSchedule = "F,*2,WSI,*100";

       private bool m_dispCityCount = true;
       private bool m_dispCityScore = true;
       private bool m_dispCityName = true;
       private bool m_dispPlayerCount = true;
       private bool m_dispPlayerScore = true;
       private bool m_dispAllianceScore = true;
       private bool m_dispAllianceRank = true;
       private bool m_dispPalaceLevel = true;
       private bool m_dispPalaceVirtue = true;

       private bool m_filtCities = true;
       private bool m_filtCastles = true;
       private bool m_filtPalaces = true;
       private bool m_filtLand = true;
       private bool m_filtWater = true;
       private bool m_filtNoAlliance = true;
       private bool m_filtNoCities = true;

       private bool m_showDetail = true;
       private bool m_groupContinent = true;
       private bool m_groupAlliance = true;
       private bool m_groupPlayer = true;
       private bool m_groupDistance = true;
       private bool m_groupPalaceLvl = true;
       private bool m_groupCityType = true;
       private bool m_groupVirtueType = true;
       private bool m_groupBordering = true;

      private static UserOptions current;

      #region Constructor
      /// <summary>
      ///   Creates a new instance of the <see cref="UserOptions"/> class.
      /// </summary>
      /// <remarks>
      ///   This method is internal to serialization.  You should always use the
      ///   <see cref="Current"/> static property to obtain the <b>UserOptions</b>.
      /// </remarks>
	   public UserOptions()
	   {
	   }
      #endregion

       #region Properties (User options)

       public bool groupBordering
       {
           get { return m_groupBordering; }
           set { m_groupBordering = value; }
       }

       public bool groupVirtueType
       {
           get { return m_groupVirtueType; }
           set { m_groupVirtueType = value; }
       }

       public bool groupCityType
       {
           get { return m_groupCityType; }
           set { m_groupCityType = value; }
       }

       public bool groupPalaceLvl
       {
           get { return m_groupPalaceLvl; }
           set { m_groupPalaceLvl = value; }
       }

       public bool groupDistance
       {
           get { return m_groupDistance; }
           set { m_groupDistance = value; }
       }

       public bool groupPlayer
       {
           get { return m_groupPlayer; }
           set { m_groupPlayer = value; }
       }

       public bool groupAlliance
       {
           get { return m_groupAlliance; }
           set { m_groupAlliance = value; }
       }

       public bool showDetail
       {
           get { return m_showDetail; }
           set { m_showDetail = value; }
       }

       public bool groupContinent
       {
           get { return m_groupContinent; }
           set { m_groupContinent = value; }
       }

       public bool liveRememberMail
       {
           get { return m_liveRememberMail; }
           set { m_liveRememberMail = value; }
       }

       public bool liveRememberPass
       {
           get { return m_liveRememberPass; }
           set { m_liveRememberPass = value; }
       }

       public bool bbCode_u
       {
           get { return m_bbCode_u; }
           set { m_bbCode_u = value; }
       }

       public bool bbCode_s
       {
           get { return m_bbCode_s; }
           set { m_bbCode_s = value; }
       }

       public bool bbCode_i
       {
           get { return m_bbCode_i; }
           set { m_bbCode_i = value; }
       }

       public bool bbCode_b
       {
           get { return m_bbCode_b; }
           set { m_bbCode_b = value; }
       }

       public bool bbCode_url
       {
           get { return m_bbCode_url; }
           set { m_bbCode_url = value; }
       }

       public bool bbCode_city
       {
           get { return m_bbCode_city; }
           set { m_bbCode_city = value; }
       }

       public bool bbCode_player
       {
           get { return m_bbCode_player; }
           set { m_bbCode_player = value; }
       }

       public bool bbCode_alliance
       {
           get { return m_bbCode_alliance; }
           set { m_bbCode_alliance = value; }
       }

       public string liveUsername
       {
           get { return m_liveUsername; }
           set { m_liveUsername = value; }
       }

       public string livePassword
       {
           get { return m_livePassword; }
           set { m_livePassword = value; }
       }

       public string liveWorld
       {
           get { return m_liveWorld; }
           set { m_liveWorld = value; }
       }

       public string zeusUsername
       {
           get { return m_zeusUsername; }
           set { m_zeusUsername = value; }
       }

       public string zeusPassword
       {
           get { return m_zeusPassword; }
           set { m_zeusPassword = value; }
       }

       public string zeusWorld
       {
           get { return m_zeusWorld; }
           set { m_zeusWorld = value; }
       }

       public int apUseSlots
       {
           get { return m_apUseSlots; }
           set { m_apUseSlots = value; }
       }

       public int apNumCottages
       {
           get { return m_apNumCottages; }
           set { m_apNumCottages = value; }
       }

       public bool apKeepExtraResNodes
       {
           get { return m_apKeepExtraResNodes; }
           set { m_apKeepExtraResNodes = value; }
       }

       public bool apClearBuildings
       {
           get { return m_apClearBuildings; }
           set { m_apClearBuildings = value; }
       }

       public bool apBuildOnlyOnOpen
       {
           get { return m_apBuildOnlyOnOpen; }
           set { m_apBuildOnlyOnOpen = value; }
       }

       public string apPlacementSchedule
       {
           get { return m_apPlacementSchedule; }
           set { m_apPlacementSchedule = value; }
       }

       public bool dispCityCount
       {
           get { return m_dispCityCount; }
           set { m_dispCityCount = value; }
       }

       public bool dispCityScore
       {
           get { return m_dispCityScore; }
           set { m_dispCityScore = value; }
       }

       public bool dispCityName
       {
           get { return m_dispCityName; }
           set { m_dispCityName = value; }
       }

       public bool dispPlayerCount
       {
           get { return m_dispPlayerCount; }
           set { m_dispPlayerCount = value; }
       }

       public bool dispPlayerScore
       {
           get { return m_dispPlayerScore; }
           set { m_dispPlayerScore = value; }
       }

       public bool dispAllianceScore
       {
           get { return m_dispAllianceScore; }
           set { m_dispAllianceScore = value; }
       }

       public bool dispAllianceRank
       {
           get { return m_dispAllianceRank; }
           set { m_dispAllianceRank = value; }
       }

       public bool dispPalaceLevel
       {
           get { return m_dispPalaceLevel; }
           set { m_dispPalaceLevel = value; }
       }

       public bool dispPalaceVirtue
       {
           get { return m_dispPalaceVirtue; }
           set { m_dispPalaceVirtue = value; }
       }

       public bool filtCities
       {
           get { return m_filtCities; }
           set { m_filtCities = value; }
       }

       public bool filtCastles
       {
           get { return m_filtCastles; }
           set { m_filtCastles = value; }
       }

       public bool filtPalaces
       {
           get { return m_filtPalaces; }
           set { m_filtPalaces = value; }
       }

       public bool filtLand
       {
           get { return m_filtLand; }
           set { m_filtLand = value; }
       }

       public bool filtWater
       {
           get { return m_filtWater; }
           set { m_filtWater = value; }
       }

       public bool filtNoAlliance
       {
           get { return m_filtNoAlliance; }
           set { m_filtNoAlliance = value; }
       }

       public bool filtNoCities
       {
           get { return m_filtNoCities; }
           set { m_filtNoCities = value; }
       }
      #endregion

      #region Static Properties
      /// <summary>
      ///   Gets the current <see cref="UserOptions"/> for the application.
      /// </summary>
      /// <value>
      ///   A <see cref="UserOptions"/> for the current user.
      /// </value>
      /// <remarks>
      ///   <b>Current</b> will load the user options file if required.  If a <see cref="SecurityException"/>
      ///   is encounter, then the default options, as per the constructor, is used.
      /// </remarks>
      public static UserOptions Current
      {
         get
         {
            if (current == null)
            {
               lock (typeof(UserOptions))
               {
                  if (current == null)
                  {
                     try
                     {
                        current = Load();
                     }
                     catch (SecurityException)
                     {
                        current = new UserOptions();
                     }
                  }
               }
            }
            return current;
         }
      }
      #endregion

      #region Serialization
      /// <summary>
      ///   Loads a the <b>UserOptions</b> file into a new instance.
      /// </summary>
      /// <returns>
      ///   A <see cref="UserOptions"/>.
      /// </returns>
      private static UserOptions Load()
      {
         if (!File.Exists(OptionsPath))
            return new UserOptions();

         XmlSerializer serializer = new XmlSerializer(typeof(UserOptions));
         using (FileStream stream = new FileStream(OptionsPath, FileMode.Open))
         {
            XmlReader reader = new XmlTextReader(stream);
            return (UserOptions) serializer.Deserialize(reader);
         }
      }

      /// <summary>
      ///   Saves the <see cref="UserOptions"/>
      /// </summary>
      /// <remarks>
      ///   A <see cref="SecurityException"/> is quietly ignored.
      /// </remarks>
      public void Save()
      {
         try
         {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (StreamWriter writer = new StreamWriter(OptionsPath))
            {
               serializer.Serialize(writer, this);
            }
         }
         catch (SecurityException)
         {
            // Do nothing.
         }
      }

      /// <summary>
      ///   Gets the fully qualified name of the ".options.xml" file.
      /// </summary>
      /// <remarks>
      ///   If a path does not exist, one is created in the following format:
      ///   <para>
      ///   <see cref="Environment.SpecialFolder">ApplicationData</see>\
      ///    <see cref="Application.CompanyName"/>\ 
      ///    <see cref="Application.ProductName"/>\ 
      ///    <i>appname</i>.options.xml
      ///   </para>
      ///   <para>
      ///    A typical <b>OptionsPath</b>, is 
      ///    "C:\Documents and Settings\<i>username</i>\Application Data\<i>company</i>\<i>product</i>\<i>appname</i>.exe.options.xml".
      ///    </para>
      /// </remarks>
      private static string OptionsPath
      {
         get
         {
            // Build the directory.
            StringBuilder path = new StringBuilder();
            path.Append(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            path.Append(Path.DirectorySeparatorChar);
            path.Append(Application.CompanyName);
            path.Append(Path.DirectorySeparatorChar);
            path.Append(Application.ProductName);
            lock (typeof(UserOptions))
            {
               string dir = path.ToString();
               if (!Directory.Exists(dir))
                  Directory.CreateDirectory(dir);
            }

            // Add the file name.
            path.Append(Path.DirectorySeparatorChar);
            path.Append(Path.GetFileName(Application.ExecutablePath));
            path.Append(@".options.xml");

            return path.ToString();
         }
      }
      #endregion
   }
}
