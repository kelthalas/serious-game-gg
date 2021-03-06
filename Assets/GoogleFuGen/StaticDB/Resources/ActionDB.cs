//----------------------------------------------
//    GoogleFu: Google Doc Unity integration
//         Copyright Â© 2013 Litteratus
//
//        This file has been auto-generated
//              Do not manually edit
//----------------------------------------------

using UnityEngine;

namespace GoogleFu
{
	[System.Serializable]
	public class ActionDBRow 
	{
		public string _NAME;
		public string _DESC;
		public int _CORRUPTIONCOST;
		public int _SEXISMECOST;
		public string _CARDEFFECT;
		public string _CARDEFFECTDESC;
		public int _ATTACK;
		public int _REPUTATION;
		public bool _CANTARGETALLIES;
		public bool _CANTARGETENEMYPLAYER;
		public bool _CANTARGETSELF;
		public bool _CANTARGETACTORS;
		public ActionDBRow(string __NAME, string __DESC, string __CORRUPTIONCOST, string __SEXISMECOST, string __CARDEFFECT, string __CARDEFFECTDESC, string __ATTACK, string __REPUTATION, string __CANTARGETALLIES, string __CANTARGETENEMYPLAYER, string __CANTARGETSELF, string __CANTARGETACTORS) 
		{
			_NAME = __NAME.Trim();
			_DESC = __DESC.Trim();
			{
			int res;
				if(int.TryParse(__CORRUPTIONCOST, out res))
					_CORRUPTIONCOST = res;
				else
					Debug.LogError("Failed To Convert CORRUPTIONCOST string: "+ __CORRUPTIONCOST +" to int");
			}
			{
			int res;
				if(int.TryParse(__SEXISMECOST, out res))
					_SEXISMECOST = res;
				else
					Debug.LogError("Failed To Convert SEXISMECOST string: "+ __SEXISMECOST +" to int");
			}
			_CARDEFFECT = __CARDEFFECT.Trim();
			_CARDEFFECTDESC = __CARDEFFECTDESC.Trim();
			{
			int res;
				if(int.TryParse(__ATTACK, out res))
					_ATTACK = res;
				else
					Debug.LogError("Failed To Convert ATTACK string: "+ __ATTACK +" to int");
			}
			{
			int res;
				if(int.TryParse(__REPUTATION, out res))
					_REPUTATION = res;
				else
					Debug.LogError("Failed To Convert REPUTATION string: "+ __REPUTATION +" to int");
			}
			{
			bool res;
				if(bool.TryParse(__CANTARGETALLIES, out res))
					_CANTARGETALLIES = res;
				else
					Debug.LogError("Failed To Convert CANTARGETALLIES string: "+ __CANTARGETALLIES +" to bool");
			}
			{
			bool res;
				if(bool.TryParse(__CANTARGETENEMYPLAYER, out res))
					_CANTARGETENEMYPLAYER = res;
				else
					Debug.LogError("Failed To Convert CANTARGETENEMYPLAYER string: "+ __CANTARGETENEMYPLAYER +" to bool");
			}
			{
			bool res;
				if(bool.TryParse(__CANTARGETSELF, out res))
					_CANTARGETSELF = res;
				else
					Debug.LogError("Failed To Convert CANTARGETSELF string: "+ __CANTARGETSELF +" to bool");
			}
			{
			bool res;
				if(bool.TryParse(__CANTARGETACTORS, out res))
					_CANTARGETACTORS = res;
				else
					Debug.LogError("Failed To Convert CANTARGETACTORS string: "+ __CANTARGETACTORS +" to bool");
			}
		}

		public int Length { get { return 12; } }

		public string this[int i]
		{
		    get
		    {
		        return GetStringDataByIndex(i);
		    }
		}

		public string GetStringDataByIndex( int index )
		{
			string ret = System.String.Empty;
			switch( index )
			{
				case 0:
					ret = _NAME.ToString();
					break;
				case 1:
					ret = _DESC.ToString();
					break;
				case 2:
					ret = _CORRUPTIONCOST.ToString();
					break;
				case 3:
					ret = _SEXISMECOST.ToString();
					break;
				case 4:
					ret = _CARDEFFECT.ToString();
					break;
				case 5:
					ret = _CARDEFFECTDESC.ToString();
					break;
				case 6:
					ret = _ATTACK.ToString();
					break;
				case 7:
					ret = _REPUTATION.ToString();
					break;
				case 8:
					ret = _CANTARGETALLIES.ToString();
					break;
				case 9:
					ret = _CANTARGETENEMYPLAYER.ToString();
					break;
				case 10:
					ret = _CANTARGETSELF.ToString();
					break;
				case 11:
					ret = _CANTARGETACTORS.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			string ret = System.String.Empty;
			switch( colID.ToUpper() )
			{
				case "NAME":
					ret = _NAME.ToString();
					break;
				case "DESC":
					ret = _DESC.ToString();
					break;
				case "CORRUPTIONCOST":
					ret = _CORRUPTIONCOST.ToString();
					break;
				case "SEXISMECOST":
					ret = _SEXISMECOST.ToString();
					break;
				case "CARDEFFECT":
					ret = _CARDEFFECT.ToString();
					break;
				case "CARDEFFECTDESC":
					ret = _CARDEFFECTDESC.ToString();
					break;
				case "ATTACK":
					ret = _ATTACK.ToString();
					break;
				case "REPUTATION":
					ret = _REPUTATION.ToString();
					break;
				case "CANTARGETALLIES":
					ret = _CANTARGETALLIES.ToString();
					break;
				case "CANTARGETENEMYPLAYER":
					ret = _CANTARGETENEMYPLAYER.ToString();
					break;
				case "CANTARGETSELF":
					ret = _CANTARGETSELF.ToString();
					break;
				case "CANTARGETACTORS":
					ret = _CANTARGETACTORS.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "NAME" + " : " + _NAME.ToString() + "} ";
			ret += "{" + "DESC" + " : " + _DESC.ToString() + "} ";
			ret += "{" + "CORRUPTIONCOST" + " : " + _CORRUPTIONCOST.ToString() + "} ";
			ret += "{" + "SEXISMECOST" + " : " + _SEXISMECOST.ToString() + "} ";
			ret += "{" + "CARDEFFECT" + " : " + _CARDEFFECT.ToString() + "} ";
			ret += "{" + "CARDEFFECTDESC" + " : " + _CARDEFFECTDESC.ToString() + "} ";
			ret += "{" + "ATTACK" + " : " + _ATTACK.ToString() + "} ";
			ret += "{" + "REPUTATION" + " : " + _REPUTATION.ToString() + "} ";
			ret += "{" + "CANTARGETALLIES" + " : " + _CANTARGETALLIES.ToString() + "} ";
			ret += "{" + "CANTARGETENEMYPLAYER" + " : " + _CANTARGETENEMYPLAYER.ToString() + "} ";
			ret += "{" + "CANTARGETSELF" + " : " + _CANTARGETSELF.ToString() + "} ";
			ret += "{" + "CANTARGETACTORS" + " : " + _CANTARGETACTORS.ToString() + "} ";
			return ret;
		}
	}
	public sealed class ActionDB
	{
		public enum rowIds {
			ACTION_CENSURE, ACTION_DECL, ACTION_REMISEDEPRIX, ACTION_DMCA, ACTION_KICKSTARTER, ACTION_BOMBE, ACTION_GAMERSAREDEAD, ACTION_MENACESDEMORT, ACTION_HACK, ACTION_PUBRETIREES, ACTION_CONFESSION, ACTION_HARCELEMENT
		};
		public string [] rowNames = {
			"ACTION_CENSURE", "ACTION_DECL", "ACTION_REMISEDEPRIX", "ACTION_DMCA", "ACTION_KICKSTARTER", "ACTION_BOMBE", "ACTION_GAMERSAREDEAD", "ACTION_MENACESDEMORT", "ACTION_HACK", "ACTION_PUBRETIREES", "ACTION_CONFESSION", "ACTION_HARCELEMENT"
		};
		public System.Collections.Generic.List<ActionDBRow> Rows = new System.Collections.Generic.List<ActionDBRow>();

		public static ActionDB Instance
		{
			get { return NestedActionDB.instance; }
		}

		private class NestedActionDB
		{
			static NestedActionDB() { }
			internal static readonly ActionDB instance = new ActionDB();
		}

		private ActionDB()
		{
			Rows.Add( new ActionDBRow("Censure",
														"Suppression massive de commentaires sur reddit \u00e0 plusieurs reprises",
														"2",
														"0",
														"DiscardEffect",
														"Enleve %ATTACK% carte al\u00e9atoire de la main adverse",
														"1",
														"0",
														"FALSE",
														"TRUE",
														"FALSE",
														"FALSE"));
			Rows.Add( new ActionDBRow("D\u00e9claration sans fondement",
														"",
														"0",
														"2",
														"DefaultEffect",
														"Reduit la r\u00e9putation de l'adversaire ou la carte cibl\u00e9e de %ATTACK%",
														"2",
														"0",
														"FALSE",
														"TRUE",
														"FALSE",
														"TRUE"));
			Rows.Add( new ActionDBRow("Remise de prix truqu\u00e9e",
														"Relation intime avec un membre du jury",
														"2",
														"0",
														"ChangeStatsEffect",
														"+%REPUTATION% \u00e0 la r\u00e9putation de la cible",
														"0",
														"5",
														"TRUE",
														"FALSE",
														"TRUE",
														"FALSE"));
			Rows.Add( new ActionDBRow("Abus de plainte DMCA",
														"L'utilisation de plaintes DMCA est parfois abus\u00e9e pour retirer des critiques n\u00e9gatives de Youtube",
														"3",
														"0",
														"DiscardEffect",
														"Enleve %ATTACK% cartes al\u00e9atoire de la main adverse",
														"1",
														"0",
														"FALSE",
														"TRUE",
														"FALSE",
														"FALSE"));
			Rows.Add( new ActionDBRow("Kickstarter r\u00e9ussi",
														"Objectif de financement participatif atteint !",
														"0",
														"0",
														"DrawEffect",
														"Pioche %ATTACK% cartes",
														"2",
														"0",
														"FALSE",
														"FALSE",
														"TRUE",
														"FALSE"));
			Rows.Add( new ActionDBRow("Alerte \u00e0 la bombe",
														"De fausses alertes \u00e0 la bombes ont \u00e9t\u00e9 utilis\u00e9es pour dissuader des discours",
														"0",
														"5",
														"DestroyIfCostEffect",
														"D\u00e9truit une carte qui coute de la corruption",
														"0",
														"0",
														"FALSE",
														"FALSE",
														"FALSE",
														"TRUE"));
			Rows.Add( new ActionDBRow("Gamers are dead",
														"Plusieurs sites sont soupconn\u00e9s de s'\u00eatre arrang\u00e9s pour une s\u00e9rie d'articles simultan\u00e9s",
														"5",
														"0",
														"DestroyIfCostEffect",
														"D\u00e9truit une carte qui coute du sexisme",
														"1",
														"0",
														"FALSE",
														"FALSE",
														"FALSE",
														"TRUE"));
			Rows.Add( new ActionDBRow("Menaces de mort",
														"Certaines personnalit\u00e9s feminine recoivent en permanence des menaces de mort",
														"0",
														"5",
														"SendToHandEffect",
														"Renvoie une carte dans la main du joueur. Si la main est pleine, d\u00e9truit la carte",
														"0",
														"0",
														"TRUE",
														"FALSE",
														"FALSE",
														"TRUE"));
			Rows.Add( new ActionDBRow("Hack de 4chan",
														"Les utilisateurs anonymes de 4chan, bien qu'ayant des m\u00e9thodes douteuse, soutiennent The Fine Young Capitalists",
														"2",
														"0",
														"ChangePlayerStatsEffect",
														"Augmente le sexisme de l'adversaire de %REPUTATION%",
														"0",
														"5",
														"FALSE",
														"TRUE",
														"FALSE",
														"FALSE"));
			Rows.Add( new ActionDBRow("Retirer les publicit\u00e9s",
														"Intel a temporairement retir\u00e9 ses publicit\u00e9s de Gamasutra suite la pression du mouvement GamerGate",
														"0",
														"2",
														"ChangeStatsEffect",
														"%ATTACK% \u00e0 l'attaque d'une carte",
														"-2",
														"0",
														"FALSE",
														"FALSE",
														"FALSE",
														"TRUE"));
			Rows.Add( new ActionDBRow("Confession",
														"",
														"0",
														"0",
														"ChangeHighestPlayerStatEffect",
														"%ATTACK% au plus \u00e9lev\u00e9 entre corruption et sexisme. Partag\u00e9 en cas d'\u00e9galit\u00e9",
														"-6",
														"0",
														"FALSE",
														"FALSE",
														"TRUE",
														"FALSE"));
			Rows.Add( new ActionDBRow("Harcelement",
														"Le mouvement GamerGate a attir\u00e9 le support de personnes tr\u00e8s vocales, utilisant le harcelement pour effrayer l'opposition",
														"0",
														"3",
														"PreventAttackEffect",
														"Empeche une carte d'attaquer le tour suivant",
														"1",
														"0",
														"FALSE",
														"FALSE",
														"FALSE",
														"TRUE"));
		}
		public ActionDBRow GetRow(rowIds rowID)
		{
			ActionDBRow ret = null;
			try
			{
				ret = Rows[(int)rowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( rowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public ActionDBRow GetRow(string rowString)
		{
			ActionDBRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), rowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( rowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}

	}

}
