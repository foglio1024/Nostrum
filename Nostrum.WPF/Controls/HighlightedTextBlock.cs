using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;

namespace Nostrum.WPF.Controls
{
    // todo: docs
    public class HighlightedTextBlock : TextBlock
    {
        public string HighlightedText
        {
            get => (string)GetValue(HighlightedTextProperty);
            set => SetValue(HighlightedTextProperty, value);
        }
        public static readonly DependencyProperty HighlightedTextProperty = DependencyProperty.Register("HighlightedText",
                                                                                                        typeof(string),
                                                                                                        typeof(HighlightedTextBlock),
                                                                                                        new FrameworkPropertyMetadata(null, OnDataChanged));

        public Brush HighlightForeground
        {
            get => (Brush)GetValue(HighlightForegroundProperty);
            set => SetValue(HighlightForegroundProperty, value);
        }
        public static readonly DependencyProperty HighlightForegroundProperty = DependencyProperty.Register("HighlightForeground",
                                                                                                            typeof(Brush),
                                                                                                            typeof(HighlightedTextBlock));

        public Brush HighlightBackground
        {
            get => (Brush)GetValue(HighlightBackgroundProperty);
            set => SetValue(HighlightBackgroundProperty, value);
        }
        public static readonly DependencyProperty HighlightBackgroundProperty = DependencyProperty.Register("HighlightBackground",
                                                                                                            typeof(Brush),
                                                                                                            typeof(HighlightedTextBlock));

        public FontFamily HighlightFontFamily
        {
            get => (FontFamily)GetValue(HighlightFontFamilyProperty);
            set => SetValue(HighlightFontFamilyProperty, value);
        }
        public static readonly DependencyProperty HighlightFontFamilyProperty = DependencyProperty.Register("HighlightFontFamily",
                                                                                                            typeof(FontFamily),
                                                                                                            typeof(HighlightedTextBlock));

        public HighlightedTextBlock() : base() { }

        static void OnDataChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var textBlock = (HighlightedTextBlock)source;
            if (string.IsNullOrWhiteSpace(textBlock.Text)) return;

            var txt = textBlock.Text;

            var parsedRuns = new HighlightedTextParser(textBlock, ((string)e.NewValue).ToLowerInvariant()).Parse();

            textBlock.Inlines.Clear();

            if (parsedRuns.Any())
            {
                textBlock.Inlines.AddRange(parsedRuns);
            }
            else
            {
                textBlock.Inlines.Add(new Run(txt));
            }
        }

        class HighlightedTextParser
        {
            readonly HighlightedTextBlock _source;

            // starting text
            readonly string _text;

            // normalized text (_text ToLowerInvariant)
            readonly string _normalizedText;

            // normalized query tokens (split by space and ToLowerInvariant)
            readonly List<string> _queryTokens;

            // parsed TokenInfo from _queryTokens
            readonly List<TokenInfo> _tokens = new();

            // resulting Runs
            readonly List<Run> _output = new();

            public HighlightedTextParser(HighlightedTextBlock tb, string query)
            {
                _source = tb;
                _text = tb.Text;
                _normalizedText = _text.ToLowerInvariant();
                _queryTokens = query.ToLowerInvariant().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            public List<Run> Parse()
            {

                if (_queryTokens.Count == 0) return _output; // no query tokens found in text, return

                BuildTokenInfo();

                if (_tokens.Count == 0) return _output; // no token info was built, return

                // if the text starts with an unformatted part, add it now
                if (_tokens[0].Index != 0)
                {
                    AddNormalRun(_text[.._tokens[0].Index]);
                }

                // cycle through the TokenInfos and generate Runs
                for (var i = 0; i < _tokens.Count; i++)
                {
                    // check whether this token is already contained in a previous one
                    var isContainedInPrevious = i > 0 && _tokens[i - 1].Contains(_tokens[i]);
                    if (!isContainedInPrevious)
                    {
                        // this token of interest is not contained in any previous one, we can add it
                        AddFormattedRun(_text[_tokens[i].Index.._tokens[i].EndIndex]);
                    }

                    var isAtEnd = _tokens[i].EndIndex == _text.Length;
                    // the text doesn't end with the current token, add any following unformatted piece
                    if (!isAtEnd)
                    {
                        // the start index of the unformatted piece will be:
                        // - the end index of the newly added formatted piece, if the token is not contained in a previous one
                        // - the end index of the previously added formatted piece, if the token is already contained in a previous one
                        var unformattedStart = isContainedInPrevious
                            ? _tokens[i - 1].EndIndex
                            : _tokens[i].EndIndex;

                        // the end index of the unformatted piece will be:
                        // - the start index of the next formatted piece, if any
                        // - the last character of the whole text, if there aren't any more tokens left
                        var unformattedEnd = i != _tokens.Count - 1
                            ? _tokens[i + 1].Index
                            : _text.Length;

                        // check bounds of the array before adding the unformatted piece	
                        if (unformattedEnd - unformattedStart <= 0 || unformattedEnd > _text.Length) continue;

                        // add the unformatted piece
                        AddNormalRun(_text[unformattedStart..unformattedEnd]);
                    }
                }

                return _output;
            }

            void BuildTokenInfo()
            {
                while (true)
                {
                    // store the current amount of already parsed tokens
                    var count = _tokens.Count;
                    foreach (var queryToken in _queryTokens)
                    {
                        // get the last added TokenInfo of the same query string
                        var lastSameAdded = _tokens.LastOrDefault(t => t.Token.Equals(queryToken));
                        // if another TokenInfo of the same query string is found, use its EndIndex as
                        // startIdx to find the next occurrence, else start from the beginning
                        var startIdx = lastSameAdded != null ? lastSameAdded.EndIndex : 0;
                        // get the index of the next occurrence
                        var idx = _normalizedText.IndexOf(queryToken, startIdx);
                        if (idx == -1) continue; // if no occurrence is found, continue
                                                 // create the new TokenInfo
                        var newInfo = new TokenInfo { Index = idx, Token = queryToken };
                        // check if any token containing this one was already added to the list
                        if (_tokens.Any(x => x.Contains(newInfo))) continue;
                        // add the TokenInfo
                        _tokens.Add(newInfo);
                    }

                    // check if any new TokenInfo was added during last iteration: if not, break
                    if (count == _tokens.Count) break;
                }

                // sort the tokens by index
                _tokens.Sort();
            }

            void AddNormalRun(string text)
            {
                _output.Add(new Run(text));
            }

            void AddFormattedRun(string text)
            {
                _output.Add(new Run(text)
                {
                    Foreground = _source.HighlightForeground ?? _source.Foreground,
                    Background = _source.HighlightBackground ?? _source.Background,
                    FontFamily = _source.HighlightFontFamily ?? _source.FontFamily
                });
            }

            class TokenInfo : IComparable
            {
                public string Token { get; init; } = "";
                public int Index { get; init; }
                public int EndIndex => Index + Token.Length;
                public int Length => Token.Length;

                public int CompareTo(object? obj)
                {
                    if (obj is not TokenInfo other) return -1;
                    if (other.Index > Index) return -1;
                    if (other.Index < Index) return 1;
                    return 0;
                }

                /// <summary>
                /// Check if this <see cref="TokenInfo"/> contains the passed in argument.
                /// </summary>
                /// <param name="other">another TokenInfo</param>
                /// <returns>true if the argument is contained in this TokenInfo</returns>
                public bool Contains(TokenInfo other)
                {
                    return Token.Contains(other.Token) && other.Index >= Index && other.EndIndex <= EndIndex;
                }
            }
        }

    }
}
