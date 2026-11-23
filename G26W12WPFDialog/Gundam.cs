namespace G26W12WPFDialog;

public sealed record Gundam(string Name, string Model, string Faction);

public static class KoreanExtensions {
    /// <summary>주격 조사 (이/가)</summary>
    public static string WithSubject(this string text)
        => $"{text}{(HasJongsung(text) ? "이" : "가")}";

    /// <summary>목적격 조사 (을/를)</summary>
    public static string WithObject(this string text)
        => $"{text}{(HasJongsung(text) ? "을" : "를")}";

    /// <summary>보조사 / 주제 (은/는)</summary>
    public static string WithTopic(this string text)
        => $"{text}{(HasJongsung(text) ? "은" : "는")}";

    /// <summary>접속 조사 (과/와)</summary>
    public static string WithAnd(this string text)
        => $"{text}{(HasJongsung(text) ? "과" : "와")}";

    /// <summary>방향/수단 조사 (으로/로) - 'ㄹ' 받침 예외 처리 포함</summary>
    public static string WithDirection(this string text) {
        if (string.IsNullOrEmpty(text)) return text;
        char last = text[^1];
        if (last < '가' || last > '힣') return $"{text}로";

        int jongsung = (last - '가') % 28;
        // 받침이 없거나(0), 'ㄹ' 받침(8)이면 "로", 그 외 받침은 "으로"
        return $"{text}{(jongsung == 0 || jongsung == 8 ? "로" : "으로")}";
    }

    /// <summary>마지막 글자의 받침(종성) 유무 판별</summary>
    public static bool HasJongsung(this string text) {
        if (string.IsNullOrEmpty(text)) return false;

        char last = text[^1]; // 맨 마지막 글자
        if (last < '가' || last > '힣') return false;

        return (last - '가') % 28 != 0;
    }
}
