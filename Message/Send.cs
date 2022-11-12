using Unity.Entities;
using ProjectM;

namespace Message;

public static class Send {
    public static void AllOnlinePlayers(EntityManager em, string message) {
        ServerChatUtils.SendSystemMessageToAllClients(em, message);
    }
}
